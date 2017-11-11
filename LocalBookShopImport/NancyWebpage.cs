using System;
using System.IO;
using Nancy;

namespace LocalBookShopImport
{
    public class NancyWebpage : NancyModule
    {
        public NancyWebpage()
        {
            Get("/", parameters => { return "CSV Upload Tool"; });
            Post("/shops/{id}", async parameters =>
            {
                if (this.Request.Body != Stream.Null)
                {
                    ImportCSV importer = new ImportCSV();
                    importer.ReadCsv(parameters.id, this.Context.Request.Body); 
                }
            });
        }
    }
}