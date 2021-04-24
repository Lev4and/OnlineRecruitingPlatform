﻿using OnlineRecruitingPlatform.Importers.API.DaDataRu.OKVED2;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.Importers.Tests.API.DaDataRu.OKVED2
{
    public class IndustriesImporterTests
    {
        private readonly IndustriesImporter _importer;

        public IndustriesImporterTests()
        {
            _importer = new IndustriesImporter();
        }

        [Fact]
        public async Task Import_WithParams()
        {
            await _importer.Start();

            while (_importer.IsRunning())
            {

            }
        }
    }
}
