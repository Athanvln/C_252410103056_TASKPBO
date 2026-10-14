using System;
using System.Collections.Generic;

namespace SistemKaryawan
{
    // Class Karyawan
    public class Karyawan
    {
        public string Nama { get; set; }
        public double Gaji { get; set; }

        public Karyawan(string nama, double gaji)
        {
            Nama = nama;
            Gaji = gaji;
        }

        public virtual void Kerja()
        {
            Console.WriteLine($"{Nama} sedang bekerja.");
        }

        public virtual void InfoKaryawan()
        {
            Console.WriteLine($"Nama: {Nama} | Gaji: Rp{Gaji:N0}");
        }
    }

    //Class Tetap
    public class Tetap : Karyawan
    {
        public double Tunjangan { get; set; }

        public Tetap(string nama, double gaji, double tunjangan) : base(nama, gaji)
        {
            Tunjangan = tunjangan;
        }

        public double HitungGajiTotal()
        {
            return Gaji + Tunjangan;
        }

        public override void Kerja()
        {
            Console.WriteLine($"{Nama} bekerja sebagai karyawan tetap.");
        }

        public override void InfoKaryawan()
        {
            Console.WriteLine($"[Tetap] Nama: {Nama} | Gaji Pokok: Rp{Gaji:N0} | Tunjangan: Rp{Tunjangan:N0} | Total: Rp{HitungGajiTotal():N0}");
        }
    }

    // Class Kontrak
    public class Kontrak : Karyawan
    {
        public int Durasi { get; set; }

        public Kontrak(string nama, double gaji, int durasi) : base(nama, gaji)
        {
            Durasi = durasi;
        }

        public void CekKontrak()
        {
            Console.WriteLine($"Sisa durasi kontrak {Nama} adalah {Durasi} bulan.");
        }

        public override void Kerja()
        {
            Console.WriteLine($"{Nama} sedang bekerja sesuai durasi kontrak.");
        }

        public override void InfoKaryawan()
        {
            Console.WriteLine($"[Kontrak] Nama: {Nama} | Gaji: Rp{Gaji:N0} | Durasi Kontrak: {Durasi} bulan");
        }
    }

    // Subclass dari Class Tetap
    public class Manager : Tetap
    {
        public Manager(string nama, double gaji, double tunjangan) : base(nama, gaji, tunjangan) { }

        public override void Kerja()
        {
            Console.WriteLine($"Manager {Nama} sedang mengawasi jalannya proyek");
        }

        public void Memimpin()
        {
            Console.WriteLine($"Manager {Nama} sedang memimpin rapat.");
        }
    }

    public class Staff : Tetap
    {
        public Staff(string nama, double gaji, double tunjangan) : base(nama, gaji, tunjangan) { }

        public override void Kerja()
        {
            Console.WriteLine($"Staff {Nama} sedang menyelesaikan tugas operasional harian.");
        }

        public void KerjakanTugas()
        {
            Console.WriteLine($"Staff {Nama} sedang mengerjakan tugas yang diberikan.");
        }
    }

    // Subclass dari Class Kontrak
    public class Magang : Kontrak
    {
        public Magang(string nama, double gaji, int durasi) : base(nama, gaji, durasi) { }

        public override void Kerja()
        {
            Console.WriteLine($"Anak Magang {Nama} sedang belajar.");
        }

        public void Belajar()
        {
            Console.WriteLine($"Magang {Nama} sedang mempelajari modul operasional perusahaan.");
        }
    }

    public class Freelancer : Kontrak
    {
        public Freelancer(string nama, double gaji, int durasi) : base(nama, gaji, durasi) { }

        public override void Kerja()
        {
            Console.WriteLine($"Freelancer {Nama} sedang menggerjakan proyek sesuai kesepakatan.");
        }

        public void AmbilProyek()
        {
            Console.WriteLine($"Freelancer {Nama} telah mengambil proyek baru.");
        }
    }

    // Class Perusahaan
    public class Perusahaan
    {
        private List<Karyawan> daftarKaryawan = new List<Karyawan>();

        public void TambahKaryawan(Karyawan karyawan)
        {
            daftarKaryawan.Add(karyawan);
            Console.WriteLine($"Berhasil menambahkan {karyawan.Nama} ke sistem perusahaan.");
        }

        public void DaftarKaryawan()
        {
            Console.WriteLine("\n[   DAFTAR SELURUH KARYAWAN   ]");
            foreach (var k in daftarKaryawan)
            {
                k.InfoKaryawan();
            }
        }
    }

    // Main Method
    class Program
    {
        static void Main(string[] args)
        {
            // objek perushaan
            Perusahaan ptAbdi = new Perusahaan();

            // objek karyawan
            Manager manager = new Manager("Robby", 20000000, 6000000);
            Staff staff = new Staff("Bima", 7000000, 2000000);
            Magang magang = new Magang("Andrew", 2000000, 3);
            Freelancer freelancer = new Freelancer("Febri", 10000000, 6);

            // Tambahkan ke perusahaan
            Console.WriteLine("[   PROSES TAMBAH KARYAWAN   ]");
            ptAbdi.TambahKaryawan(manager);
            ptAbdi.TambahKaryawan(staff);
            ptAbdi.TambahKaryawan(magang);
            ptAbdi.TambahKaryawan(freelancer);

            // Tampilkan semua data
            ptAbdi.DaftarKaryawan();

            // Polymorphism
            Console.WriteLine("\n[  DEMONSTRASI POLYMORPHISM  ]");
            List<Karyawan> listKaryawan = new List<Karyawan> { manager, staff, magang, freelancer };
            foreach (var k in listKaryawan)
            {
                k.Kerja();
            }

            // Panggil method khusus
            Console.WriteLine("\n[   METHOD KHUSUS   ]");
            manager.Memimpin();
            staff.KerjakanTugas();
            magang.Belajar();
            freelancer.AmbilProyek();
            Console.WriteLine($"Total Gaji Manager: Rp{manager.HitungGajiTotal():N0}");
            magang.CekKontrak();
        }
    }
}