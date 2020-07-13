# Ocelot Custom Aggregation Example
Minial example of custom aggregator in Ocelot.

## Running
- Open .sln in Visual Studio.
- Ensure that Solution is configured to start all projects as self hosted.
- Hit F5.

You should get a browser window that opens to http://localhost:5200/api/aggregate, the custom aggregation endpoint.
This endpoint simply returns an array of the json responses from the other two servers.