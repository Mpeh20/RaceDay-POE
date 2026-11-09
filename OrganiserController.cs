using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "Organiser")]
public class OrganiserController : Controller
{
    private readonly IApiService _apiService;
    public OrganiserController(IApiService apiService) => _apiService = apiService;

    public async Task<IActionResult> Dashboard()
    {
        // Assuming your API has an endpoint for organiser stats
        var events = await _apiService.GetAsync<List<EventDto>>("events/organiser"); 
        return View(events);
    }

    [HttpGet]
    public IActionResult CreateEvent() => View();

    [HttpPost]
    public async Task<IActionResult> CreateEvent(EventDto model, IFormFile bannerImage)
    {
        if (ModelState.IsValid)
        {
            // 1. Create the event
            var response = await _apiService.PostAsync("events", model);
            
            if (response.IsSuccessStatusCode && bannerImage != null)
            {
                // 2. Upload image via API (API handles Azure Blob)
                var eventId = await response.Content.ReadFromJsonAsync<int>(); // Assuming API returns ID
                using var content = new MultipartFormDataContent();
                using var stream = bannerImage.OpenReadStream();
                content.Add(new StreamContent(stream), "file", bannerImage.FileName);
                
                await _apiService.PostMultipartAsync($"events/{eventId}/upload-image", content);
            }
            return RedirectToAction(nameof(Dashboard));
        }
        return View(model);
    }
}
