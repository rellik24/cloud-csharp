using Google.Cloud.Storage.V1;


public class ListFilesSample
{
    public IEnumerable<Google.Apis.Storage.v1.Data.Object> ListFiles()
    {
        var storage = StorageClient.Create();
        var storageObjects = storage.ListObjects(Global.bucket_name);
        Console.WriteLine($"Files in bucket {Global.bucket_name}:");
        foreach (var storageObject in storageObjects)
        {
            Console.WriteLine(storageObject.Name);
        }

        return storageObjects;
    }
}