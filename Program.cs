using System;

class Program
{
    public class Student
    {
        public string Numara { get; set; } 
        public string Ad { get; set; }     
        public string Soyad { get; set; }    
        public string DersAdi { get; set; }
        public int Vize { get; set; }    
        public int Final { get; set; }       
        public double Ortalama { get; set; }  
        public string Durum { get; set; }     
        public Student Next { get; set; }       


        public Student(string numara, string ad, string soyad, string dersAdi, int vize, int final)
        {
            this.Numara = numara;
            this.Ad = ad;
            this.Soyad = soyad;
            this.DersAdi = dersAdi;
            this.Vize = vize;
            this.Final = final;

            this.Ortalama = this.Vize * 0.40 + this.Final * 0.60;
            this.Durum = this.Ortalama < 50 ? "Kaldı" : "Geçti";
            this.Next = null;
        }
    }

    public class StudentList
    {
        private Student head;
        public void AddStudent(string numara, string ad, string soyad, string dersAdi, int vize, int final)
        {
            Student newStudent = new Student(numara, ad, soyad, dersAdi, vize, final);

            if (head == null)
            {
                head = newStudent;
            }
            else
            {
                Student temp = head;
                while (temp.Next != null)
                {
                    temp = temp.Next;
                }
                temp.Next = newStudent;
            }
            Console.WriteLine("Öğrenci eklendi.");
        }

        public void RemoveStudent(string numara)
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş, silinecek öğrenci yok.");
                return;
            }

            if (head.Numara == numara)
            {
                head = head.Next;
                Console.WriteLine($"{numara} numaralı öğrenci silindi.");
                return;
            }

            Student current = head;
            while (current.Next != null && current.Next.Numara != numara)
            {
                current = current.Next;
            }

            if (current.Next == null)
            {
                Console.WriteLine($"{numara} numaralı öğrenci bulunamadı.");
            }
            else
            {
                current.Next = current.Next.Next;
                Console.WriteLine($"{numara} numaralı öğrenci silindi.");
            }
        }
        public void PrintStudents()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş.");
                return;
            }

            Student temp = head;
            while (temp != null)
            {
                Console.WriteLine($"Numara: {temp.Numara}, Adı: {temp.Ad}, Soyadı: {temp.Soyad}, Ders: {temp.DersAdi}, Vize: {temp.Vize}, Final: {temp.Final}, Ortalama: {temp.Ortalama}, Durum: {temp.Durum}");
                temp = temp.Next;
            }
        }
        public void ShowTopStudent()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş.");
                return;
            }

            Student temp = head;
            Student topStudent = head;

            while (temp != null)
            {
                if (temp.Ortalama > topStudent.Ortalama)
                {
                    topStudent = temp;
                }
                temp = temp.Next;
            }

            Console.WriteLine($"En başarılı öğrenci: {topStudent.Ad} {topStudent.Soyad}, Numara: {topStudent.Numara}, Ortalama: {topStudent.Ortalama}, Durum: {topStudent.Durum}");
        }
    } 
    static void Main(string[] args)
    {
        StudentList studentList = new StudentList();

        while (true)
        {
            Console.WriteLine("\nÖğrenci Kayıt Uygulaması");
            Console.WriteLine("1 - Öğrenci Ekle");
            Console.WriteLine("2 - Öğrenci Sil");
            Console.WriteLine("3 - Öğrencileri Yazdır");
            Console.WriteLine("4 - En Başarılı Öğrenciyi Göster");
            Console.WriteLine("5 - Programı Kapat");
            Console.Write("Seçiminizi yapın: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Öğrencinin numarasını girin: ");
                    string numara = Console.ReadLine();
                    Console.Write("Öğrencinin adını girin: ");
                    string ad = Console.ReadLine();
                    Console.Write("Öğrencinin soyadını girin: ");
                    string soyad = Console.ReadLine();
                    Console.Write("Dersin adını girin: ");
                    string dersAdi = Console.ReadLine();
                    Console.Write("Öğrencinin vize notunu girin: ");
                    int vize = int.Parse(Console.ReadLine());
                    Console.Write("Öğrencinin final notunu girin: ");
                    int final = int.Parse(Console.ReadLine());
                    studentList.AddStudent(numara, ad, soyad, dersAdi, vize, final);
                    break;

                case 2:
                    Console.Write("Silmek istediğiniz öğrencinin numarasını girin: ");
                    string numaraToDelete = Console.ReadLine();
                    studentList.RemoveStudent(numaraToDelete);
                    break;

                case 3:
                    studentList.PrintStudents();
                    break;

                case 4:
                    studentList.ShowTopStudent();
                    break;

                case 5:
                    Console.WriteLine("Program sonlandırılıyor...");
                    return;

                default:
                    Console.WriteLine("Geçersiz seçim! Lütfen tekrar deneyin.");
                    break;
            }
        }
    }
}
