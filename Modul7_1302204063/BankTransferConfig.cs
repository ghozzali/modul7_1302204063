using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Modul7_1302204063
{
    public class Config
    {
        public BankTransferConfig conf;
        public string filePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public string fileConfigName = "bank_transfer_config.json";
        public Config() 
        {
            try
            {
                ReadConfigFile();
            }
            catch
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }
        private BankTransferConfig ReadConfigFile()
        {
            String jsonString = File.ReadAllText(filePath + @"\" + fileConfigName);
            conf = JsonSerializer.Deserialize<BankTransferConfig>(jsonString);
            return conf;
        }

        private void SetDefault()
        {
            trnsfer transfer = new trnsfer(25000000, 6500, 15000);
            List<string> methods = new List<string> { "RTO (real-time)", "SKN", "RGTS", "BI FAST" };
            confirm confirmation = new confirm("yes", "ya");
            conf = new BankTransferConfig("en", transfer, methods, confirmation);
        }

        private void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(conf, options);
            string fullFilePath = filePath + @"\" + fileConfigName;
            File.WriteAllText(fullFilePath, jsonString);
        }
    }

    public class BankTransferConfig
    {
        public string lang { get; set; }
        public trnsfer transfer { get; set; }
        public List<string> methods { get; set; }
        public confirm confirmation { get; set; }

        public BankTransferConfig() { }

        public BankTransferConfig(string lang, trnsfer transfer, List<string> methods, confirm confirmation) 
        {
            this.lang = lang;
            this.transfer = transfer;
            this.methods = methods;
            this.confirmation = confirmation;
        }
    }
    public class trnsfer
    {
        public int threshold { get; set; }
        public int low_fee { get; set; }
        public int high_fee { get; set; }

        public trnsfer() { }
        public trnsfer (int threshold, int low_fee, int high_fee)
        {
            this.threshold = threshold;
            this.low_fee = low_fee;
            this.high_fee = high_fee;
        }
    }

    public class confirm
    {
        public string en { get; set; }
        public string id { get; set; }

        public confirm() { }
        public confirm(string en, string id)
        {
            this.en = en;
            this.id = id;
        }
    }
}
