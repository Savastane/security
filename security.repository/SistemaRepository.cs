
using Raven.Client.Documents.Session;
using Raven.Client.Documents;

namespace site.repository.raven
{
    public class SistemaRepository /*: ISistemaRepository*/
    {
        private readonly IAsyncDocumentSession session;


        public SistemaRepository(IAsyncDocumentSession dbSession)
        {
            this.session = dbSession;
        }

        public void ApplyScriptInicial()
        {
            
        }

        public void Backup()
        {
            var temp = $"http://localhost:8080{Guid.NewGuid()}";
            //Directory.CreateDirectory(temp);

            //Contexto.Store
            //        .DatabaseCommands
            //        .GlobalAdmin
            //        .StartBackup(temp, new DatabaseDocument(), incremental: false, databaseName: "INEP")
            //        .WaitForCompletion();

            //var dir = $"http://localhost:8080{ DateTime.Now.ToString("yyyy/MM/dd/")}";
            //var arquivoZip = $"{dir}{ DateTime.Now.ToString("HH-mm-ss")}.zip";
            //Directory.CreateDirectory(dir);
            //ZipFile.CreateFromDirectory(temp, arquivoZip);
            Directory.Delete(temp, true);
        }
    }
}
