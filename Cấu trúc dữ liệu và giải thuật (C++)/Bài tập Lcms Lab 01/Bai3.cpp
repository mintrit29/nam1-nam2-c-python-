#include <iostream>
#include <math.h>
using namespace std;

struct DIEM{
    int x,y;
};

void NHAPDIEM(DIEM &diem){
    cout << "Nhap x: ";
    cin >> diem.x;
    cout << "Nhap y: ";
    cin >> diem.y;
}

void XUATDIEM(DIEM diem){
    cout << "Diem x la: " << diem.x << endl;
    cout<< "Diem y la: " << diem.y << endl;
}

float TINHKHOANGCACH(const DIEM &diem1, const DIEM &diem2) {
    return sqrt(pow(diem2.x - diem1.x, 2) + pow(diem2.y - diem1.y, 2));
}

float TINHKHOANGCACH_OX(const DIEM &diem1, const DIEM &diem2) {
    return abs(diem2.x - diem1.x); // Sử dụng abs để đảm bảo kết quả không âm
}

float TINHKHOANGCACH_OY(const DIEM &diem1, const DIEM &diem2) {
    return abs(diem2.y - diem1.y); // Sử dụng abs để đảm bảo kết quả không âm
}

DIEM TIMDIEMDOIXUNGQUAGOC(const DIEM &diem) {
    DIEM diemDoiXung;
    diemDoiXung.x = -diem.x;
    diemDoiXung.y = -diem.y;
    return diemDoiXung;
}

DIEM TIMDIEMDOIXUNGQUAPHANGIAC(const DIEM &diem) {
    DIEM diemDoiXung;
    diemDoiXung.x = diem.y;
    diemDoiXung.y = diem.x;
    return diemDoiXung;
}

DIEM TIMDIEMDOIXUNGQUAPHANGIAC2(const DIEM &diem) {
    DIEM diemDoiXung;
    diemDoiXung.x = -diem.y;
    diemDoiXung.y = -diem.x;
    return diemDoiXung;
}

int main() {
    int choice;
    int a, b; 
    DIEM diem, diem1, diem2, diemDoiXung;
    float ox, oy;
    do {
        cout << "---Menu---\n";
        cout << "1.Nhap diem\n";
        cout << "2.Xuat diem\n";
        cout << "3.Khoang cach giua 2 diem\n";
        cout << "4.Khoang cach giua 2 diem theo truc Ox\n";
        cout << "5.Khoang cach giua 2 diem theo truc Oy\n";
        cout << "6.Tim diem doi xung\n";
        cout << "7.Tim diem doi xung theo truc Ox\n";
        cout << "8.Tim diem doi xung theo truc Oy\n";
        cout << "0.Thoat\n";
        cout << "Nhap vao lua chon cua ban:\n";
        cin >> choice;
        switch (choice) {
            case 1:
            NHAPDIEM(diem);
            break;
            case 2:
            XUATDIEM(diem);
            break;
            case 3:
            cout << "Nhap toa do cho diem 1:" << endl;
            NHAPDIEM(diem1);
            cout << "Nhap toa do cho diem 2:" << endl;
            NHAPDIEM(diem2);
            cout << "Khoang cach giua hai diem la: " << TINHKHOANGCACH(diem1, diem2) << endl;
            break;
            case 4:
            ox = TINHKHOANGCACH_OX(diem1, diem2);
            cout << "Khoang cach giua hai diem theo phuong Ox la: " << ox << endl;
            break;
            case 5:
            oy = TINHKHOANGCACH_OY(diem1, diem2);
            cout << "Khoang cach giua hai diem theo phuong Oy la: " << oy << endl;
            break;
            case 6:
            NHAPDIEM(diem);
            diemDoiXung = TIMDIEMDOIXUNGQUAGOC(diem);
            cout << "Diem doi xung qua goc toa do la: (" << diemDoiXung.x << ", " << diemDoiXung.y << ")" << endl;
            case 7:
            NHAPDIEM(diem);
            diemDoiXung = TIMDIEMDOIXUNGQUAPHANGIAC(diem);
            cout << "Diem doi xung qua duong phan giac thu nhat la: (" << diemDoiXung.x << ", " << diemDoiXung.y << ")" << endl;
            break;
            case 8:
            NHAPDIEM(diem);
            diemDoiXung = TIMDIEMDOIXUNGQUAPHANGIAC2(diem);
            cout << "Diem doi xung qua duong phan giac thu hai la: (" << diemDoiXung.x << ", " << diemDoiXung.y << ")" << endl;
            break;
        }
    } while (choice != 0);
}