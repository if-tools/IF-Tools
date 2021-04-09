# IF-Tools
A website with tools for Infinite Flight Live.

## Tools
These are the current available IF Live tools:
 - **Flight Lookup** - Find flights by their callsign, IFC username or Flight/User Id.
 - **Live Flights** - View current flights on any given server.
 - **Active ATCs** - View currently active frequencies on any given server (except Casual).
 - **Server Status** - View current player count on any given server.
 - **User Info** - Find users by their IFC username / User Id and view their stats.

## Building
IF-Tools is built with ASP.NET Core. Follow these steps to build and run a local copy of this website:

 1. Clone this repository using `git clone`.
 2. Go to the project folder (`IF-Tools`).
 3. Run `dotnet run`. This will build and run the app.

You must have .NET 5.0 installed. You must also have the following environment variable set in your environment:
 - `IF_LIVE_KEY` - Your IF Live Api key. See [here](https://infiniteflight.com/guide/developer-reference/live-api/overview#obtaining-an-api-key) for information on obtaining it.

## Contributing
Want to contribute? That's great, thanks! Clone the `develop` branch of this repo to get started, and then open a new Pull Request when you've made your desired changes (don't forget to describe them).
