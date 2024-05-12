using RequestTrackerBLLibrary;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
namespace RequestTrackerFullApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var context = new RequestTrackerContext();
            var employeeRepository = new EmployeeRepository(context);
            var requestRepository = new RequestRepository(context);
            var requestSolutionRepository = new RequestSolutionRepository(context);
            var solutionFeedbackRepository = new SolutionFeedbackRepository(context);

            var rtservice = new RequestTrackerService(employeeRepository, requestRepository, requestSolutionRepository, solutionFeedbackRepository);

            while (true)
            {
                Console.WriteLine("Request Tracker App");
                Console.WriteLine("1. Login");
                Console.WriteLine("0. Exit");
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await Login(rtservice);
                        break;
                    case "0":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static async Task Login(RequestTrackerService rtservice)
        {
            Console.WriteLine("Login");
            Console.Write("Enter your username: ");
            var username = Console.ReadLine();
            Console.Write("Enter your password: ");
            var password = Console.ReadLine();
            var user = await rtservice.GetUserByUsernameAndPasswordAsync(username, password);
            if (user != null)
            {
                if (user.Role == "User")
                {
                    await UserMenu(user, rtservice);
                }
                else if (user.Role == "Admin")
                {
                    await AdminMenu(user, rtservice);
                }
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
            }
        }

        static async Task UserMenu(Employee user, RequestTrackerService rtservice)
        {
            while (true)
            {
                Console.WriteLine($"Welcome {user.Name} (User)");
                Console.WriteLine("1. Raise Request");
                Console.WriteLine("2. View Request Status");
                Console.WriteLine("3. View Solutions");
                Console.WriteLine("4. Give Feedback");
                Console.WriteLine("5. Respond to Solution");
                Console.WriteLine("0. Logout");
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await RaiseRequest(user, rtservice);
                        break;
                    case "2":
                        await ViewRequestStatus(user, rtservice);
                        break;
                    case "3":
                        await ViewSolutions(user, rtservice);
                        break;
                    case "4":
                        await GiveFeedback(user, rtservice);
                        break;
                    case "5":
                        await RespondToSolution(user, rtservice);
                        break;
                    case "0":
                        Console.WriteLine("Logging out...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static async Task AdminMenu(Employee user, RequestTrackerService rtservice)
        {
            while (true)
            {
                Console.WriteLine($"Welcome {user.Name} (Admin)");
                Console.WriteLine("1. Raise Request");
                Console.WriteLine("2. View Request Status (All Requests)");
                Console.WriteLine("3. View Solutions (All Solutions)");
                Console.WriteLine("4. Give Feedback (Only for requests raised by you)");
                Console.WriteLine("5. Respond to Solution (Only for requests raised by you)");
                Console.WriteLine("6. Provide Solution");
                Console.WriteLine("7. Mark Request as Closed");
                Console.WriteLine("8. View Feedbacks (Only feedbacks given to you)");
                Console.WriteLine("0. Logout");
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await RaiseRequest(user, rtservice);
                        break;
                    case "2":
                        await ViewAllRequests(user, rtservice);
                        break;
                    case "3":
                        await ViewAllSolutions(user, rtservice);
                        break;
                    case "4":
                        await GiveFeedback(user, rtservice);
                        break;
                    case "5":
                        await RespondToSolution(user, rtservice);
                        break;
                    case "6":
                        await ProvideSolution(user, rtservice);
                        break;
                    case "7":
                        await MarkRequestAsClosed(user, rtservice);
                        break;
                    case "8":
                        await ViewFeedbacks(user, rtservice);
                        break;
                    case "0":
                        Console.WriteLine("Logging out...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static async Task RaiseRequest(Employee user, RequestTrackerService rtservice)
        {
            Console.WriteLine(user.Id);
            Console.WriteLine("Raising a new request...");
            Console.Write("Enter your request message: ");
            string requestMessage = Console.ReadLine();
            await rtservice.RaiseRequest(requestMessage, user.Id);
        }

        static async Task ViewRequestStatus(Employee user, RequestTrackerService rtservice)
        {
            Console.WriteLine("Viewing request status...");
            List<Request> userRequests = await rtservice.GetUserRequestsAsync(user.Id);
            if (userRequests.Count == 0)
            {
                Console.WriteLine("No requests found for this user.");
            }
            else
            {
                foreach (var request in userRequests)
                {
                    Console.WriteLine($"Request Number: {request.RequestNumber}");
                    Console.WriteLine($"Message: {request.RequestMessage}");
                    Console.WriteLine($"Status: {request.RequestStatus}");
                    Console.WriteLine($"Raised By: {request.RaisedByEmployee.Name}");
                    Console.WriteLine();
                }
            }
        }

        static async Task ViewSolutions(Employee user, RequestTrackerService rtservice)
        {
            Console.WriteLine("Viewing solutions...");
            List<Request> userRequests = await rtservice.GetUserRequestsAsync(user.Id);
            if (userRequests.Count == 0)
            {
                Console.WriteLine("No solutions found for requests raised by this user.");
            }
            else
            {
                foreach (var request in userRequests)
                {                    
                    if (request.RequestSolutions == null || request.RequestSolutions.Count == 0)
                    {
                        Console.WriteLine($"No solutions found for Request Number: {request.RequestNumber}");
                    }
                    else
                    {
                        List<RequestSolution> requestSolutions = request.RequestSolutions.ToList();
                        foreach (var solution in requestSolutions)
                        {
                            Console.WriteLine($"Solution ID: {solution.SolutionId}");
                            Console.WriteLine($"Description: {solution.SolutionDescription}");
                            Console.WriteLine($"Solved By: {solution.SolvedByEmployee.Name}");
                            Console.WriteLine($"Solved Date: {solution.SolvedDate}");
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

        static async Task GiveFeedback(Employee user, RequestTrackerService rtservice)
        {
            Console.WriteLine("Giving feedback...");
            Console.Write("Enter the Solution ID: ");
            int solutionId;
            while (!int.TryParse(Console.ReadLine(), out solutionId))
            {
                Console.WriteLine("Invalid input. Please enter a valid Solution ID: ");
            }
            Console.Write("Enter your rating (1-5 stars): ");
            float rating;
            while (!float.TryParse(Console.ReadLine(), out rating) || rating < 1 || rating > 5)
            {
                Console.WriteLine("Invalid input. Please enter a rating between 1 and 5: ");
            }
            Console.Write("Enter your remarks (optional): ");
            string remarks = Console.ReadLine();
            await rtservice.GiveFeedback(solutionId,rating,remarks,user.Id);
            Console.WriteLine("Feedback submitted successfully!");
        }

        static async Task RespondToSolution(Employee user, RequestTrackerService rtservice)
        {
            Console.WriteLine("Responding to solution...");
            Console.Write("Enter the Solution ID: ");
            int solutionId;
            while (!int.TryParse(Console.ReadLine(), out solutionId))
            {
                Console.WriteLine("Invalid input. Please enter a valid Solution ID: ");
            }
            Console.Write("Enter your comment: ");
            string comment = Console.ReadLine();
            try
            {
                await rtservice.RespondToSolution(solutionId, comment);
                Console.WriteLine("Response added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

        }

        static async Task ViewAllRequests(Employee user, RequestTrackerService rtservice)
        {
            Console.WriteLine("Viewing all requests...");
            try
            {
                var requests = await rtservice.GetAllRequestsAsync();
                if (requests.Count == 0)
                {
                    Console.WriteLine("No requests found.");
                }
                else
                {
                    foreach (var request in requests)
                    {
                        Console.WriteLine($"Request Number: {request.RequestNumber}, Message: {request.RequestMessage}, Status: {request.RequestStatus}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static async Task ViewAllSolutions(Employee user, RequestTrackerService rtservice)
        {
            Console.WriteLine("Viewing all solutions...");
            try
            {
                var solutions = await rtservice.GetAllSolutionsAsync();
                if (solutions.Count == 0)
                {
                    Console.WriteLine("No solutions found.");
                }
                else
                {
                    foreach (var solution in solutions)
                    {
                        Console.WriteLine($"Solution ID: {solution.SolutionId}, Description: {solution.SolutionDescription}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static async Task ProvideSolution(Employee user, RequestTrackerService rtservice)
        {
            Console.WriteLine("Providing solution...");
            try
            {
                Console.Write("Enter the Request ID: ");
                int requestId;
                while (!int.TryParse(Console.ReadLine(), out requestId))
                {
                    Console.WriteLine("Invalid input. Please enter a valid Request ID: ");
                }
                Console.Write("Enter the solution message: ");
                string solutionMessage = Console.ReadLine();
                await rtservice.ProvideSolution(requestId,solutionMessage,user.Id);
                Console.WriteLine("Solution provided successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static async Task MarkRequestAsClosed(Employee user, RequestTrackerService rtservice)
        {
            Console.WriteLine("Marking request as closed...");
            try
            {
                Console.Write("Enter the Request ID: ");
                int requestId;
                while (!int.TryParse(Console.ReadLine(), out requestId))
                {
                    Console.WriteLine("Invalid input. Please enter a valid Request ID: ");
                }
                await rtservice.MarkRequestAsClosed(requestId);
                Console.WriteLine("Request marked as closed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static async Task ViewFeedbacks(Employee user, RequestTrackerService rtservice)
        {
            Console.WriteLine("Viewing feedbacks...");
            try
            {
                var feedbacks = await rtservice.GetFeedbacksForAdminAsync(user.Id);
                if (feedbacks.Count == 0)
                {
                    Console.WriteLine("No feedbacks found.");
                }
                else
                {
                    foreach (var feedback in feedbacks)
                    {
                        Console.WriteLine($"Feedback ID: {feedback.FeedbackId}, Rating: {feedback.Rating}, Remarks: {feedback.Remarks}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

    }
}
