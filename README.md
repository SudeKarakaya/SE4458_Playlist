# Playlist Rest API
A playlist app that allows users to add, delete and list all songs.

## Source Code
Github Repository: https://github.com/SudeKarakaya/SE4458_Playlist

## Live Website Link
https://playlist-f8h4e7bbd5fyc0dm.canadacentral-01.azurewebsites.net/swagger/index.html

## Design
- Built using ASP.NET Core Web API(.Net 8)
- Data is stored in memory database 

## Assumptions
- ID's are automatically incremented.
- All data resets when the app restarts since the app uses in memory database.

## Issues Encountered
- Needed to allow Swagger UI in development.
- Initially the root URL returned 404.
