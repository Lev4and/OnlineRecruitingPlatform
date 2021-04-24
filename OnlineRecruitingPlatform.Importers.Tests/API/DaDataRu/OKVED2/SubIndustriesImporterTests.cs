﻿using OnlineRecruitingPlatform.Importers.API.DaDataRu.OKVED2;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRecruitingPlatform.Importers.Tests.API.DaDataRu.OKVED2
{
    public class SubIndustriesImporterTests
    {
        private readonly SubIndustriesImporter _importer;

        public SubIndustriesImporterTests()
        {
            _importer = new SubIndustriesImporter();
        }

        [Fact]
        public async Task Import_WithParams()
        {
            await _importer.Start();
        }
    }
}
