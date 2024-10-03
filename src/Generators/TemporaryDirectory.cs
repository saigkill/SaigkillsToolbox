using System.IO;

namespace Generators
{
  /// <summary>
  /// A class to create a temporary directory.
  /// </summary>
  public static class TemporaryDirectory
  {
    /// <summary>
    /// Erstellt einen temporären Ordner und gibt den Pfad zurück.
    /// </summary>
    /// <returns>Pfad zum temporären Ordner.</returns>
    public static string GetTemporaryDirectory()
    {
      string tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());

      if (Directory.Exists(tempDirectory))
      {
        return GetTemporaryDirectory();
      }
      else
      {
        Directory.CreateDirectory(tempDirectory);
        return tempDirectory;
      }
    }
  }
}
