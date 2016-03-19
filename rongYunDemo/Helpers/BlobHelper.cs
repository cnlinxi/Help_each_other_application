using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace rongYunDemo.Helpers
{
    public class BlobHelper
    {
        CloudStorageAccount storageAccount;
        CloudBlobClient blobClient;
        public BlobHelper()
        {
            storageAccount =CloudStorageAccount.Parse(Configurations.storageAccount);
            blobClient = storageAccount.CreateCloudBlobClient();
        }

        /// <summary>
        /// 创建容器,并设置容器的权限为Blob
        /// </summary>
        /// 容器名必须为小写和数字,必须介于 3 到 63 个字符,详见;https://www.azure.cn/zh-cn/documentation/articles/storage-dotnet-how-to-use-blobs/
        /// <param name="containerName">容器名</param>
        /// <returns></returns>
        public async Task CreateContainer(string containerName)
        {
            if (blobClient == null)
                return;
            containerName = containerName.ToLower();
            CloudBlobContainer container = blobClient.GetContainerReference(containerName);
            await container.CreateIfNotExistsAsync();
            await container.SetPermissionsAsync(new BlobContainerPermissions {
                PublicAccess=BlobContainerPublicAccessType.Blob
            });
        }

        public async Task UploadFromStream(Stream stream,string containerName,string blobName,string contentType="image/jpeg")
        {
            if (blobClient == null || stream == null)
                return;
            containerName = containerName.ToLower();
            try
            {
                CloudBlobContainer container = blobClient.GetContainerReference(containerName);
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
                await blockBlob.UploadFromStreamAsync(stream.AsInputStream());
                blockBlob.Properties.ContentType = contentType;
                await blockBlob.SetPropertiesAsync();
            }
            catch { }
        }

        public async Task UploadFromStorageFile(StorageFile file,string containerName,string blobName,string contentType= "image/jpeg")
        {
            if (blobClient == null || file == null)
                return;
            containerName = containerName.ToLower();
            try
            {
                CloudBlobContainer container = blobClient.GetContainerReference(containerName);
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
                await blockBlob.UploadFromFileAsync(file);
                blockBlob.Properties.ContentType = contentType;
                await blockBlob.SetPropertiesAsync();
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 下载文件到Output流中
        /// </summary>
        /// <param name="containerName">容器名</param>
        /// <param name="blobName">blob名</param>
        /// <returns></returns>
        public async Task<IOutputStream> DownloadToStream(string containerName,string blobName)
        {
            if (blobClient == null)
                return null;
            containerName = containerName.ToLower();
            try
            {
                CloudBlobContainer container = blobClient.GetContainerReference(containerName);
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(blobName);
                IOutputStream stream = new InMemoryRandomAccessStream();
                await blockBlob.DownloadToStreamAsync(stream);
                return stream;
            }
            catch
            {
                return null;
            }
        }
    }
}
