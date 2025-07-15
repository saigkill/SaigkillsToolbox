using System.Threading.Tasks;

using Ardalis.Result;

using WebDav;

namespace Saigkill.Toolbox.Services
{
  /// <summary>
  /// Interface IWebDavService
  /// </summary>
  public interface IWebDavService
  {
    /// <summary>
    /// Gets the wd parameters.
    /// </summary>
    /// <returns>WebDavClientParams.</returns>
    WebDavClientParams GetParams();

    /// <summary>
    /// Downloads the file asynchronous.
    /// </summary>
    /// <param name="remoteFilepath">The remote filepath.</param>
    /// <param name="localFilepath">The local filepath.</param>
    /// <returns>Task&lt;System.Boolean&gt;.</returns>
    Task<Result> DownloadFileAsync(string remoteFilepath, string localFilepath);

    /// <summary>
    /// Deletes the file asynchronous.
    /// </summary>
    /// <param name="remoteFilepath">The remote filepath.</param>
    /// <returns>Task&lt;System.Boolean&gt;.</returns>
    Task<Result> DeleteFileAsync(string remoteFilepath);

    /// <summary>
    /// Uploads the file asynchronous.
    /// </summary>
    /// <param name="localFilepath">The local filepath.</param>
    /// <param name="remoteFilepath">The remote filepath.</param>
    /// <returns>Task&lt;System.Boolean&gt;.</returns>
    Task<Result> UploadFileAsync(string localFilepath, string remoteFilepath);
  }
}
