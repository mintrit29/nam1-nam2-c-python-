#include <iostream>
using namespace std;

struct GIO {
    int GIO;
    int PHUT;
    int GIAY;
};

bool KIEMTRAGIOHOPLE(GIO gio) {
    return (gio.GIO >= 0 && gio.GIO <= 23) &&
           (gio.PHUT >= 0 && gio.PHUT <= 59) &&
           (gio.GIAY >= 0 && gio.GIAY <= 59);
}

void NHAPGIO(GIO &gio) {
    do {
        cout << "Nhap gio: ";
        cin >> gio.GIO;
        cout << "Nhap phut: ";
        cin >> gio.PHUT;
        cout << "Nhap giay: ";
        cin >> gio.GIAY;
    } while (!KIEMTRAGIOHOPLE(gio));
}

void XUATGIO(GIO gio) {
    cout << "Gio: ";
    if (gio.GIO < 10) cout << "0";
    cout << gio.GIO << ":";
    if (gio.PHUT < 10) cout << "0";
    cout << gio.PHUT << ":";
    if (gio.GIAY < 10) cout << "0";
    cout << gio.GIAY << endl;
}

GIO TONGHAIGIO(GIO gio1, GIO gio2) {
    GIO tong;
    int giayTong = (gio1.GIO * 3600 + gio1.PHUT * 60 + gio1.GIAY) + (gio2.GIO * 3600 + gio2.PHUT * 60 + gio2.GIAY);
    tong.GIO = giayTong / 3600;
    tong.PHUT = (giayTong % 3600) / 60;
    tong.GIAY = giayTong % 60;
    return tong;
}

int main() {
    int choice;
    GIO gio1, gio2, tong;
    do {
        cout << "---Menu---\n";
        cout << "1. Nhap gio\n";
        cout << "2. Xuat gio\n";
        cout << "3. Tinh tong hai gio\n";
        cout << "0. Thoat\n";
        cout << "Nhap lua chon cua ban: ";
        cin >> choice;

        switch (choice) {
            case 1:
                cout << "Nhap gio thu nhat:\n";
                NHAPGIO(gio1);
                cout << "Nhap gio thu hai:\n";
                NHAPGIO(gio2);
                break;
            case 2:
                cout << "Gio thu nhat:\n";
                XUATGIO(gio1);
                cout << "Gio thu hai:\n";
                XUATGIO(gio2);
                break;
            case 3:
                tong = TONGHAIGIO(gio1, gio2);
                cout << "Tong hai gio la:\n";
                XUATGIO(tong);
                break;
            case 0:
                cout << "Ket thuc chuong trinh.\n";
                break;
            default:
                cout << "Lua chon khong hop le.\n";
                break;
        }
    } while (choice != 0);

    return 0;
}
