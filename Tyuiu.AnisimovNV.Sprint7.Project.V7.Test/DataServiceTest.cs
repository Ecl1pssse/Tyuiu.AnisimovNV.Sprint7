using System.IO;
using Xunit;
using Tyuiu.AnisimovNV.Sprint7.Project.V7.Lib;

namespace Tyuiu.AnisimovNV.Sprint7.Project.V7.Test
{
    public class DataServiceTest
    {
        [Fact]
        public void LoadFromFile_ValidFile_ReturnsData()
        {
            string path = "test.csv";
            File.WriteAllText(path, "Подъезд;Квартира;Площадь;Жилая;Комнат;Фамилия;Дата;Семья;Дети;Долг;Примечание\n1;101;55.5;42.3;2;Иванов;15.03.2010;3;1;True;\n1;102;48.7;36.5;1;Петрова;20.05.2015;2;0;False;");
            var ds = new DataService();
            string[,] result = ds.LoadFromFile(path);
            Assert.Equal(3, result.GetLength(0));
            Assert.Equal(11, result.GetLength(1));
            Assert.Equal("Иванов", result[1, 5]);
            File.Delete(path);
        }

        [Fact]
        public void SearchBySurname_FindsRecords()
        {
            string[,] data = {
                {"Подъезд", "Квартира", "Площадь", "Жилая", "Комнат", "Фамилия", "Дата", "Семья", "Дети", "Долг", "Примечание"},
                {"1", "101", "55.5", "42.3", "2", "Иванов", "15.03.2010", "3", "1", "True", ""},
                {"1", "102", "48.7", "36.5", "1", "Петрова", "20.05.2015", "2", "0", "False", ""},
                {"2", "201", "67.8", "50.2", "3", "Сидоров", "10.10.2005", "4", "2", "True", ""}
            };
            var ds = new DataService();
            int[] result = ds.SearchBySurname(data, "Иванов");
            Assert.Equal(1, result.Length);
            Assert.Equal(1, result[0]);
        }

        [Fact]
        public void GetStatistics_ReturnsCorrectData()
        {
            string[,] data = {
                {"Подъезд", "Квартира", "Площадь", "Жилая", "Комнат", "Фамилия", "Дата", "Семья", "Дети", "Долг", "Примечание"},
                {"1", "101", "55.5", "42.3", "2", "Иванов", "15.03.2010", "3", "1", "True", ""},
                {"1", "102", "48.7", "36.5", "1", "Петрова", "20.05.2015", "2", "0", "False", ""}
            };
            var ds = new DataService();
            string[] result = ds.GetStatistics(data);
            Assert.Contains("Всего квартир: 2", result[0]);
        }
    }
}