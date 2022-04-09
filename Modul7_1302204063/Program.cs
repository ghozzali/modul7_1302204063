using System;

namespace Modul7_1302204063
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Config ConfigBankTransfer = new Config();
            Console.WriteLine("Language: ");
            string bahasa = Console.ReadLine();
            int jumlahTransfer, biayaTransfer = 0, i = 0,  totalBiaya;

            if (bahasa == "en")
            {
                Console.WriteLine("Please insert the amount of money to transfer: ");
                jumlahTransfer = int.Parse(Console.ReadLine());
                if (jumlahTransfer <= ConfigBankTransfer.conf.transfer.threshold)
                {
                    biayaTransfer = ConfigBankTransfer.conf.transfer.low_fee;
                } else if (jumlahTransfer > ConfigBankTransfer.conf.transfer.threshold)
                {
                    biayaTransfer = ConfigBankTransfer.conf.transfer.high_fee;
                }
                totalBiaya = jumlahTransfer + biayaTransfer;
                Console.WriteLine("Transfer fee = " + biayaTransfer + " Total amount = " + totalBiaya);
                Console.WriteLine("Select transfer method: ");
                foreach(string metode in ConfigBankTransfer.conf.methods)
                {
                    i++;
                    Console.WriteLine(i + ". " +  metode);
                }
                int metodeTransfer = int.Parse(Console.ReadLine());
                Console.WriteLine("Please type " + ConfigBankTransfer.conf.confirmation.en + " to confirm the transaction: ");
                string konfirmasi = Console.ReadLine();
                if (konfirmasi == ConfigBankTransfer.conf.confirmation.en)
                {
                    Console.WriteLine("The transfer is completed");
                } else
                {
                    Console.WriteLine("Transfer is cancelled");
                }
            } else if (bahasa == "id")
            {
                Console.WriteLine("Masukkan jumlah uang yang akan di transfer: ");
                jumlahTransfer = int.Parse(Console.ReadLine());
                if (jumlahTransfer <= ConfigBankTransfer.conf.transfer.threshold)
                {
                    biayaTransfer = ConfigBankTransfer.conf.transfer.low_fee;
                }
                else if (jumlahTransfer > ConfigBankTransfer.conf.transfer.threshold)
                {
                    biayaTransfer = ConfigBankTransfer.conf.transfer.high_fee;
                }
                totalBiaya = jumlahTransfer + biayaTransfer;
                Console.WriteLine("Biaya Transfer = " + biayaTransfer + " Total Biaya = " + totalBiaya);
                Console.WriteLine("Pilih metode transfer: ");
                foreach (string metode in ConfigBankTransfer.conf.methods)
                {
                    i++;
                    Console.WriteLine(i + ". " + metode);
                }
                int metodeTransfer = int.Parse(Console.ReadLine());
                Console.WriteLine("Ketik " + ConfigBankTransfer.conf.confirmation.id + " untuk mengonfirmasi transaksi: ");
                string konfirmasi = Console.ReadLine();
                if (konfirmasi == ConfigBankTransfer.conf.confirmation.id)
                {
                    Console.WriteLine("Proses transfer berhasil");
                }
                else
                {
                    Console.WriteLine("Transfer dibatalkan");
                }
            }

        }
    }
}