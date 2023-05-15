// Copyright 2022 Google Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";

var url = $"http://0.0.0.0:{port}";

var app = builder.Build();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        string filePath = "index.html";
        if (File.Exists(filePath))
        {
            context.Response.ContentType = "text/html";
            await context.Response.SendFileAsync(filePath);
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
        }
    });
    endpoints.MapGet("/api/list", async context =>
    {
        var list = new ListFilesSample();
        var files = list.ListFiles();

        foreach (var file in files)
        {
            await context.Response.WriteAsync(file.ToString() ?? "");
        }

    });
});


app.Run(url);

public static class Global
{
    public static string project_id { get; set; } = Environment.GetEnvironmentVariable("PROJECT_ID") ?? "";
    public static string key_ring { get; set; } = Environment.GetEnvironmentVariable("KEY_RING") ?? "";
    public static string key_name { get; set; } = Environment.GetEnvironmentVariable("KEY_NAME") ?? "";
    public static string key_version { get; set; } = Environment.GetEnvironmentVariable("KEY_VERSION") ?? "";
    public static string bucket_name { get; set; } = Environment.GetEnvironmentVariable("BUCKET_NAME") ?? "";
}