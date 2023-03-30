using Microsoft.AspNetCore.Components;
using Radzen;

namespace BlazorEcommerce.Client.Pages;

public partial class Counter
{
    [Inject] public NotificationService _notificationService {get ; set; } = null!;

    private int currentCount = 0;

    private void IncrementCount()
    {
        currentCount++;

        if (currentCount % 7 == 0)
        {
            _notificationService.Notify(
                NotificationSeverity.Success,
                "You are doing good",
                "this is details",
                5e3);
        }
    }
}
