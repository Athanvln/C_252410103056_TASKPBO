Sistem Manajemen Karyawan

Fitur Utama 

Dalam proyek ini, terdapat pemanfaatan beberapa pilar dasar Object-Oriented Programming (OOP):

Inheritance: 
  - Class `Karyawan` bertindak sebagai *parent class*.
  - Class `Tetap` dan `Kontrak` mewarisi properti dari `Karyawan`.
  - Class `Manager` & `Staff` diturunkan dari `Tetap`.
  - Class `Magang` & `Freelancer` diturunkan dari `Kontrak`.
  
Polymorphism: Method `Kerja()` dan `InfoKaryawan()` menggunakan keyword `virtual` dan `override` sehingga jalannya fungsi disesuaikan dengan peran masing-masing karyawan.

Encapsulation: Pengelolaan daftar karyawan menggunakan `List<Karyawan>` secara privat di dalam class `Perusahaan`.

Output Program
<img width="1179" height="579" alt="Screenshot 2026-10-14 221016" src="https://github.com/user-attachments/assets/35148188-548a-4879-bf0c-19df028d2788" />
