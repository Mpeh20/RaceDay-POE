using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "Participant")]
public class ParticipantController : Controller
{
    private readonly IApiService _apiService;
    public ParticipantController(IApiService apiService) => _apiService = apiService;

    public async Task<IActionResult> Index()
    {
        var events = await _apiService.GetAsync<List<EventDto>>("events/upcoming");
        return View(events);
    }

    [HttpPost]
    public async Task<IActionResult> Enroll(int eventId, int categoryId)
    {
        var response = await _apiService.PostAsync($"events/{eventId}/enroll", new { CategoryId = categoryId });
        
        if (response.IsSuccessStatusCode)
        {
            TempData["Success"] = "Successfully enrolled!";
        }
        else
        {
            TempData["Error"] = "Enrollment failed. You may already be enrolled.";
        }
        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> MyEvents()
    {
        var enrollments = await _apiService.GetAsync<List<EnrollmentDto>>("participants/my-events");
        return View(enrollments);
    }
}
