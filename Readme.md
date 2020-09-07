# C# interview exercises

The exercises are made up of four parts, the first three focusing on code and the fourth focusing on architecture and system design.
You'll find the fourth exercise in the file Webhooks.md in this repository.

## Part 1

This is a WiFi credentials generator micro-service that responds to Visitor check-in events with credentials (username/password)

The function to generate the credentials is provided and is located in `Service/Credentials/CredentialsService.cs` The visitors should be searched through via the Proxyclick API: https://api.proxyclick.com/v1/docs/#introduction

Use this company Id for the exercise: `CO-CXER585`

Client Id: `98C5EB84170E6FB3617C47A5B17ECFACB4A0FD49`

Client secret, username & password will be sent via email

### Goal

- Make sure that all the tests cases located in `Tests/VisitorTests.cs` and `Tests/CheckInTests.cs` pass. Do not modify the test files
- Start by writing the body of the function `ListVisitors` (`Visitors/VisitorService.cs`) that search through visitors using the Proxyclick API
- Ensure the `ListVisitors` method returns a valid visitor class, not a generic object
- Then, write code in the function `HandleCheckIn` (`CheckIn/CheckInHandler.cs`)
- Feel free to create more files with your structured code if you feel it is necessary
- For the last test case, we would like to optimize the process so that consecutive checks-in of the same visitor do not need to call generate multiple times. The first result should be saved in-memory
- Create a zip file with your solution (the project) and send it back to your interviewer

### Flow

1. There is a check-in event coming in. (Unit test start)
1. Find visitor corresponding to the email-address from Proxyclick API
1. If the visitor isn't found -> throw an error
1. If visitor is found but firstname/lastname mismatch -> Update visitor using the function `UpdateVisitor`
1. Generate credentials for this visitor and return it

## Part 2

Please write the function in Service/Sender.cs that will call the EmailSender.SendEmail() function. If SendEmail() throws an error, it should retry 4 times with 10min interval, then stop retrying while logging an error message. Please write the unit tests for this function

## Part 3

Please write an API that will serve your previously defined functions

- `GET /visitors`: this endpoint should allow to search visitors and return an array of visitors by calling the `ListVisitors`
- `POST /check-in`: This endpoint receives a `VisitorEvent` in the POST body and should call the `HandleCheckIn` method. It should returns a 204 if everything went well
- Write your code in the `/api` folder
- Feel free to use any framework for writing your API
- Make sure to handle error cases and return appropriate responses

## Part 4

Complete the exercise in the Webhooks.md file.
