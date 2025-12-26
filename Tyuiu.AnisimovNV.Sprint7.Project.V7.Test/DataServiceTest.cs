using Xunit;
using Tyuiu.AnisimovNV.Sprint7.Project.V7.Lib;
using System.IO;

namespace Tyuiu.AnisimovNV.Sprint7.Project.V7.Test
{
    public class DataServiceTest
    {
        [Fact]
        public void LoadFromFile_ValidFile_ReturnsCorrectData()
        {
            // Arrange
            string testFile = "test.csv";
            File.WriteAllText(testFile, "Подъезд;Квартира;Площадь;Жилая;Комнат;Фамилия;Дата;Семья;Дети;Долг;Примечание\n1;101;55.5;42.3;2;Иванов;15.03.2010;3;1;True;\n1;102;48.7;36.5;1;Петрова;20.05.2015;2;0;False;");

            var service = new DataService();

            // Act
            var result = service.LoadFromFile(testFile);

            // Assert
            Assert.Equal(3, result.GetLength(0)); // 1 header + 2 rows
            Assert.Equal(11, result.GetLength(1)); // 11 columns
            Assert.Equal("Иванов", result[1, 5]);
            Assert.Equal("Петрова", result[2, 5]);

            // Cleanup
            File.Delete(testFile);
        }

        [Fact]
        public void SearchBySurname_FindsMatchingRecords()
        {
            // Arrange
            var service = new DataService();
            string[,] testData = {
                {"Подъезд", "Квартира", "Площадь", "Жилая", "Комнат", "Фамилия", "Дата", "Семья", "Дети", "Долг", "Примечание"},
                {"1", "101", "55.5", "42.3", "2", "Иванов", "15.03.2010", "3", "1", "True", ""},
                {"1", "102", "48.7", "36.5", "1", "Петрова", "20.05.2015", "2", "0", "False", ""},
                {"2", "201", "67.8", "50.2", "3", "Сидоров", "10.10.2005", "4", "2", "True", ""},
                {"2", "202", "73.4", "55.1", "3", "Иванова", "05.12.2018", "3", "1", "False", ""}
            };

            // Act
            var result = service.SearchBySurname(testData, "Иван");

            // Assert
            Assert.Equal(2, result.Length);
            Assert.Equal(1, result[0]); // Иванов
            Assert.Equal(4, result[1]); // Иванова
        }

        [Fact]
        public void GetDebtStatistics_ReturnsCorrectCounts()
        {
            // Arrange
            var service = new DataService();
            string[,] testData = {
                {"Подъезд", "Квартира", "Площадь", "Жилая", "Комнат", "Фамилия", "Дата", "Семья", "Дети", "Долг", "Примечание"},
                {"1", "101", "55.5", "42.3", "2", "Иванов", "15.03.2010", "3", "1", "True", ""},
                {"1", "102", "48.7", "36.5", "1", "Петрова", "20.05.2015", "2", "0", "False", ""},
                {"2", "201", "67.8", "50.2", "3", "Сидоров", "10.10.2005", "4", "2", "True", ""}
            };

            // Act
            var result = service.GetDebtStatistics(testData);

            // Assert
            Assert.Equal(2, result.withDebt);
            Assert.Equal(1, result.withoutDebt);
        }
    }
}