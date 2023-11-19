using volcanes_api_v2.Models.DTOs;

namespace volcanes_api_v2.Interfaces;

public interface ISpacesDigitalOceanService
{
    Task<ArchivoDescargadoDTO> DownloadFileAsync(string file);

    Task<ResponseUpload> UploadFileAsync(IFormFile file);

    Task<bool> DeleteFileAsync(string fileName, string versionId = "");
}