using Xunit;

namespace CollaboroCodeBox.Core.Tests
{
    public class BusinessServiceTest
    {
        [Fact]
        public void CodeDecipher_Success()
        {
            // Given
            var codeBoxMapping = "(1,C),(2,F),(3,A),(4,W),(5,U),(6,T),(7,Y),(8,L),(9,I),(10,S),(11,M),(12,H),(13,R),(14,N),(15,Q),(16,O),(17,B),(18,E)";

            // And
            var codeToDecipher = "11,3,7,6,12,18,2,16,13,1,18,17,18,4,9,6,12,7,16,5";

            // And
            var expectedResponse = "MAYTHEFORCEBEWITHYOU";

            // And
            var service = new BusinessService();

            // When
            var actualResponse = service.DecipherCode(codeBoxMapping, codeToDecipher);

            // Then
            Assert.Contains(expectedResponse, actualResponse);
        }

        [Fact]
        public void CodeDecipher_Failed_MissingCodeMapping()
        {
            // Given
            var codeBoxMapping = "(1,C),(2,F),(3,A),(4,W),(5,U),(6,T),(7,Y),(8,L),(9,I),(10,S),(11,M),(12,H),(13,R),(14,N),(15,Q),(16,O),(17,B),(18,E)";

            // And
            // Code 28 and 37 not present in the mapping
            var codeToDecipher = "11,3,7,6,12,18,2,16,13,1,28,37,18,4,9,6,12,7,16,5";

            // And
            var expectedResponse = "Error in processing";

            // And
            var service = new BusinessService();

            // When
            var actualResponse = service.DecipherCode(codeBoxMapping, codeToDecipher);

            // Then
            Assert.Contains(expectedResponse, actualResponse);
        }

        [Fact]
        public void CodeBoxMapping_Failed_Translation()
        {
            // Given
            // Key 14 is repeated twice
            var codeBoxMapping = "(1,C),(2,F),(3,A),(4,W),(5,U),(6,T),(7,Y),(8,L),(9,I),(10,S),(11,M),(14,H),(13,R),(14,N),(15,Q),(16,O),(17,B),(18,E)";

            // And
            var expectedResponse = "Error in processing";

            // And
            var service = new BusinessService();

            // When
            var actualResponse = service.DecipherCode(codeBoxMapping, string.Empty);

            // Then
            Assert.Contains(expectedResponse, actualResponse);
        }
    }
}
