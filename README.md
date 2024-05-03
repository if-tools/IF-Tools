# IF-Tools
A website with tools for Infinite Flight Live.

## Tools
 - **Flight Lookup** - Find flights by their callsign, IFC username or Flight/User Id.
 - **Live Flights** - View current flights on any given server.
 - **Active ATCs** - View currently active frequencies on any given server.
 - **Server Status** - View current player count on any given server.
 - **User Info** - Find users by their IFC username or User Id and view their stats.

Please [open an issue](https://github.com/if-tools/IF-Tools/issues/new?assignees=&labels=enhancement&template=feature_request.md) if you'd like to see more tools added!

## Building
IF-Tools is built with ASP.NET Core 8.0 and Blazor. Follow these steps to build and run a local copy of the app:

1. Clone this repository using `git clone`.
2. Go to the project folder (`IF-Tools`).
3. Create a `.env` file based on the provided `.env.example` with your Infinite Flight Live API Key. See [here](https://infiniteflight.com/guide/developer-reference/live-api/overview#obtaining-an-api-key) for information on obtaining an API key.

### Docker
#### Instructions:
1. Build the image and run the app using
    ```bash
    $ docker-compose up --build
    ```
2. IF-Tools will now be accessible at `localhost:5001`.

### Native
#### Requirements:
- .NET 8.0

#### Instructions:
1. Go into `IF-Tools` and build and run the app using
   ```bash
   $ dotnet run
   ```

## Contributing
Fork the `develop` branch of this repo to get started, follow the above instructions to build the app, and then open a new Pull Request when you've made your desired changes (don't forget to describe them). Thanks for your help!