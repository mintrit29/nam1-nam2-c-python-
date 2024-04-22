#include <iostream>
using namespace std;

struct NGAY {
    int ngay;
    int thang;
    int nam;
};

bool LANAMNHUAN(int nam) {
    return (nam % 4 == 0 && nam % 100 != 0) || (nam % 400 == 0);
}

int SONGAYTRONGTHANG(int thang, int nam) {
    if (thang == 2) {
        return LANAMNHUAN(nam) ? 29 : 28;
    } else if (thang == 4 || thang == 6 || thang == 9 || thang == 11) {
        return 30;
    } else {
        return 31;
    }
}

bool NGAYHOPLE(int ngay, int thang, int nam) {
    if (thang < 1 || thang > 12) {
        return false;
    }
    if (ngay < 1 || ngay > SONGAYTRONGTHANG(thang, nam)) {
        return false;
    }
    return true;
}

void NHAPNGAY(NGAY &ngay) {
    do {
        cout << "Nhap ngay: ";
        cin >> ngay.ngay;
        cout << "Nhap thang: ";
        cin >> ngay.thang;
        cout << "Nhap nam: ";
        cin >> ngay.nam;
    } while (!NGAYHOPLE(ngay.ngay, ngay.thang, ngay.nam));
}

void XUATNGAY(NGAY ngay) {
    cout << "Ngay: " << ngay.ngay << "/" << ngay.thang << "/" << ngay.nam << endl;
}

NGAY NGAYKETIEP(NGAY ngay) {
    NGAY ngayKeTiep = ngay;
    ngayKeTiep.ngay++;

    if (ngayKeTiep.ngay > SONGAYTRONGTHANG(ngayKeTiep.thang, ngayKeTiep.nam)) {
        ngayKeTiep.ngay = 1;
        ngayKeTiep.thang++;

        if (ngayKeTiep.thang > 12) {
            ngayKeTiep.thang = 1;
            ngayKeTiep.nam++;
        }
    }

    return ngayKeTiep;
}

NGAY NGAYTRUOCDO(NGAY ngay) {
    NGAY ngayTruocDo = ngay;
    ngayTruocDo.ngay--;

    if (ngayTruocDo.ngay < 1) {
        ngayTruocDo.thang--;

        if (ngayTruocDo.thang < 1) {
            ngayTruocDo.thang = 12;
            ngayTruocDo.nam--;
        }

        ngayTruocDo.ngay = SONGAYTRONGTHANG(ngayTruocDo.thang, ngayTruocDo.nam);
    }

    return ngayTruocDo;
}

int main() {
    int choice;
    NGAY ngay;
    do {
        cout << "---Menu---\n";
        cout << "1. Nhap ngay\n";
        cout << "2. Xuat ngay\n";
        cout << "3. Tim ngay ke tiep\n";
        cout << "4. Tim ngay truoc do\n";
        cout << "0. Thoat\n";
        cout << "Nhap lua chon cua ban: ";
        cin >> choice;

        switch (choice) {
            case 1:
                NHAPNGAY(ngay);
                break;
            case 2:
                XUATNGAY(ngay);
                break;
            case 3:
                ngay = NGAYKETIEP(ngay);
                cout << "Ngay ke tiep la: ";
                XUATNGAY(ngay);
                break;
            case 4:
                ngay = NGAYTRUOCDO(ngay);
                cout << "Ngay truoc do la: ";
                XUATNGAY(ngay);
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
