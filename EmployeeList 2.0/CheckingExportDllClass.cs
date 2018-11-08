using ExportManager;

namespace EmployeeList_2._0
{
    public class CheckingExportDllClass
    {
        private EmployeeList list;
        private string nameOfExport;
        private bool typeOfExport;
        public CheckingExportDllClass(EmployeeList list, string nameOfExport, bool typeOfExport)
        {
            this.list = list;
            this.nameOfExport = nameOfExport;
            this.typeOfExport = typeOfExport;
        }
        public string CallExport(out string logMessage)
        {
            Export export = new Export(nameOfExport, list.FullNames(list.CheckEmpType, typeOfExport));
            var resOfExport = export.WriteFile();
            if (resOfExport == null)
            {
                logMessage = $"Info. Файл \"{nameOfExport}\" успешно экспортирован";
                return "Файл экспортирован!";
            }
            else
            {
                logMessage = $"ERROR. Файл \"{nameOfExport}\" не может быть экспортирован. Ошибка: {resOfExport.Message}";
                return $"Экспорт невозможен. Ошибка: {resOfExport.Message}";
            }
        }
    }
}
