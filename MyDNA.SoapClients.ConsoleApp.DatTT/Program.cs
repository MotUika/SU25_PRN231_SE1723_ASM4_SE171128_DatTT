using FeedBackRatingDatTTWCFServiceReference;
using System.Text.Json;

// Entry point
Console.WriteLine("=== FeedBack Rating Console Menu ===");

IFeedBackRatingDatTTSoapService service = new FeedBackRatingDatTTSoapServiceClient(
    FeedBackRatingDatTTSoapServiceClient.EndpointConfiguration.BasicHttpBinding_IFeedBackRatingDatTTSoapService
);

bool running = true;
while (running)
{
    Console.WriteLine("\nMenu:");
    Console.WriteLine("1. Get All Feedback Ratings");
    Console.WriteLine("2. Get Feedback Rating By ID");
    Console.WriteLine("3. Create New Feedback Rating");
    Console.WriteLine("4. Update Feedback Rating");
    Console.WriteLine("5. Delete Feedback Rating");
    Console.WriteLine("0. Exit");
    Console.Write("Choose an option: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            var allFeedbacks = await service.GetFeedBackRatingDatTTAsync();
            Console.WriteLine(JsonSerializer.Serialize(allFeedbacks, new JsonSerializerOptions { WriteIndented = true }));
            break;

        case "2":
            Console.Write("Enter Feedback ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var feedback = await service.GetFeedBackRatingDatTTByIdAsync(id);
                Console.WriteLine(JsonSerializer.Serialize(feedback, new JsonSerializerOptions { WriteIndented = true }));
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
            break;

        case "3":
            var newFeedback = new FeedBackRatingDatTT();
            Console.Write("Service ID: ");
            newFeedback.ServiceDatTtid = int.Parse(Console.ReadLine());

            Console.Write("Rating (1-5): ");
            newFeedback.Rating = (sbyte)byte.Parse(Console.ReadLine());

            Console.Write("Writer Name: ");
            newFeedback.WriterName = Console.ReadLine();

            Console.Write("Title: ");
            newFeedback.Title = Console.ReadLine();

            Console.Write("Content (optional): ");
            newFeedback.Content = Console.ReadLine();

            newFeedback.IsVisible = true;
            newFeedback.CreatedAt = DateTime.Now;
            newFeedback.UpdatedAt = DateTime.Now;

            Console.Write("Feedback Score (1-100): ");
            newFeedback.FeedbackScore = int.Parse(Console.ReadLine());

            int createdId = await service.CreateFeedBackRatingDatTTAsync(newFeedback);
            Console.WriteLine(createdId > 0 ? $"Feedback created with ID {createdId}" : "Failed to create feedback.");
            break;

        case "4":
            Console.Write("Enter Feedback ID to update: ");
            if (int.TryParse(Console.ReadLine(), out int updateId))
            {
                var existing = await service.GetFeedBackRatingDatTTByIdAsync(updateId);
                if (existing == null || existing.FeedBackRatingDatTtid == 0)
                {
                    Console.WriteLine("Feedback not found.");
                    break;
                }

                Console.Write("New Rating (1-5): ");
                existing.Rating = (sbyte)byte.Parse(Console.ReadLine());

                Console.Write("New Writer Name: ");
                existing.WriterName = Console.ReadLine();

                Console.Write("New Title: ");
                existing.Title = Console.ReadLine();

                Console.Write("New Content (optional): ");
                existing.Content = Console.ReadLine();

                Console.Write("New Feedback Score (1-100): ");
                existing.FeedbackScore = int.Parse(Console.ReadLine());

                existing.UpdatedAt = DateTime.Now;

                int updated = await service.UpdateFeedBackRatingDatTTAsync(existing);
                Console.WriteLine(updated > 0 ? "Feedback updated successfully." : "Failed to update.");
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
            break;

        case "5":
            Console.Write("Enter Feedback ID to delete: ");
            if (int.TryParse(Console.ReadLine(), out int deleteId))
            {
                int deleted = await service.DeleteFeedBackRatingDatTTAsync(deleteId);
                Console.WriteLine(deleted > 0 ? "Feedback deleted." : "Failed to delete.");
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
            break;

        case "0":
            running = false;
            break;

        default:
            Console.WriteLine("Invalid option. Try again.");
            break;
    }
}

Console.WriteLine("Goodbye!");
