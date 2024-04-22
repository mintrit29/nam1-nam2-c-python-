#include <iostream>
#include <cmath>
using namespace std;

struct SOPHUC {
    double Re; // Phần thực
    double Im; // Phần ảo
};

void NSP(SOPHUC &sp) {
    cout << "Nhập phần thực: ";
    cin >> sp.Re;
    cout << "Nhập phần ảo: ";
    cin >> sp.Im;
}

void XSP(SOPHUC sp) {
    cout << "Số phức: " << sp.Re << " + " << sp.Im << "i" << endl;
}

double MODULE(SOPHUC sp) {
    return sqrt(sp.Re * sp.Re + sp.Im * sp.Im);
}

int SoSanhSoPhuc(SOPHUC sp1, SOPHUC sp2) {
    if (sp1.Re == sp2.Re && sp1.Im == sp2.Im) {
        return 0; // Hai số phức bằng nhau
    } else if ((sp1.Re < sp2.Re) || (sp1.Re == sp2.Re && sp1.Im < sp2.Im)) {
        return -1; // Số phức thứ nhất nhỏ hơn số phức thứ hai
    } else {
        return 1; // Số phức thứ nhất lớn hơn số phức thứ hai
    }
}

SOPHUC TONGSOPHUC(SOPHUC sp1, SOPHUC sp2, SOPHUC tong) {
    tong.Re = sp1.Re + sp2.Re; // Tính phần thực của tổng
    tong.Im = sp1.Im + sp2.Im; // Tính phần ảo của tổng
    return tong;
}

SOPHUC HIEUSOPHUC(SOPHUC sp1, SOPHUC sp2, SOPHUC hieu) {
    hieu.Re = sp1.Re - sp2.Re; // Tính phần thực của hiệu
    hieu.Im = sp1.Im - sp2.Im; // Tính phần ảo của hiệu
    return hieu;
}

SOPHUC TICHSOPHUC(SOPHUC sp1, SOPHUC sp2, SOPHUC tich) {
    tich.Re = sp1.Re * sp2.Re - sp1.Im * sp2.Im; // Tính phần thực của tích
    tich.Im = sp1.Re * sp2.Im + sp1.Im * sp2.Re; // Tính phần ảo của tích
    return tich;
}

SOPHUC NGHICHDAO(SOPHUC sp) {
    SOPHUC nghichdao;
    double modul = sp.Re * sp.Re + sp.Im * sp.Im;
    nghichdao.Re = sp.Re / modul;
    nghichdao.Im = -sp.Im / modul;
    return nghichdao;
}

SOPHUC THUONGSOPHUC(SOPHUC sp1, SOPHUC sp2, SOPHUC thuong) {
    SOPHUC sp2_nghichdao = NGHICHDAO(sp2); // Số phức nghịch đảo của sp2
    thuong = TICHSOPHUC(sp1, sp2_nghichdao, thuong); // Tích của sp1 và số phức nghịch đảo của sp2
    return thuong;
}

int main() {
    int choice;
    int a, b; 
    SOPHUC sp;
    SOPHUC sp1, sp2, tong, hieu, tich, thuong;
    do {
        cout << "---Menu---\n";
        cout << "1.Nhập số phức\n";
        cout << "2.Xuất số phức\n";
        cout << "3.Tính module của số phức\n";
        cout << "4.So sánh hai số phức\n";
        cout << "5.Tổng hai số phức\n";
        cout << "6.Hiệu hai số phức\n";
        cout << "7.Tích hai số phức\n";
        cout << "8.Thương hai số phức\n";
        cout << "0. Thoát\n";
        cout << "Nhập vào lựa chọn của bạn\n";
        cin >> choice;
        switch (choice) {
            case 1:
            NSP(sp);
            break;
            case 2:
            cout << "Số phức vừa nhập: ";
            XSP(sp);
            break;
            case 3:
            cout << "Module của số phức là: " << MODULE(sp) << endl;
            break;
            case 4:{
            cout << "Nhập phần thực của số phức thứ nhất: ";
            cin >> sp1.Re;
            cout << "Nhập phần ảo của số phức thứ nhất: ";
            cin >> sp1.Im;
            cout << "Nhập phần thực của số phức thứ hai: ";
            cin >> sp2.Re;
            cout << "Nhập phần ảo của số phức thứ hai: ";
            cin >> sp2.Im;
    // So sánh hai số phức
    int ketqua = SoSanhSoPhuc(sp1, sp2);
    if (ketqua == -1) {
        cout << "Số phức thứ nhất nhỏ hơn số phức thứ hai." << endl;
    } else if (ketqua == 1) {
        cout << "Số phức thứ nhất lớn hơn số phức thứ hai." << endl;
    } else {
        cout << "Hai số phức bằng nhau." << endl;
    }
            break;}
            case 5:
            cout << "Nhập phần thực của số phức thứ nhất: ";
            cin >> sp1.Re;
            cout << "Nhập phần ảo của số phức thứ nhất: ";
            cin >> sp1.Im;
            cout << "Nhập phần thực của số phức thứ hai: ";
            cin >> sp2.Re;
            cout << "Nhập phần ảo của số phức thứ hai: ";
            cin >> sp2.Im;
            // Tính tổng của hai số phức
            tong = TONGSOPHUC(sp1, sp2, tong);
            // Xuất tổng của hai số phức
            cout << "Tổng của hai số phức: " << tong.Re << " + " << tong.Im << "i" << endl;
            case 6:
            cout << "Nhập phần thực của số phức thứ nhất: ";
            cin >> sp1.Re;
            cout << "Nhập phần ảo của số phức thứ nhất: ";
            cin >> sp1.Im;
            cout << "Nhập phần thực của số phức thứ hai: ";
            cin >> sp2.Re;
            cout << "Nhập phần ảo của số phức thứ hai: ";
            cin >> sp2.Im;
            // Tính hiệu của hai số phức
            hieu = HIEUSOPHUC(sp1, sp2, hieu);
            // Xuất hiệu của hai số phức
            cout << "Hiệu của hai số phức: " << hieu.Re << " + " << hieu.Im << "i" << endl;
            break;
            case 7:
            cout << "Nhập phần thực của số phức thứ nhất: ";
            cin >> sp1.Re;
            cout << "Nhập phần ảo của số phức thứ nhất: ";
            cin >> sp1.Im;
            cout << "Nhập phần thực của số phức thứ hai: ";
            cin >> sp2.Re;
            cout << "Nhập phần ảo của số phức thứ hai: ";
            cin >> sp2.Im;
            tich = TICHSOPHUC(sp1, sp2, tich);
            cout << "Tích của hai số phức: " << tich.Re << " + " << tich.Im << "i" << endl;
            break;
            case 8:
            cout << "Nhập phần thực của số phức thứ nhất: ";
            cin >> sp1.Re;
            cout << "Nhập phần ảo của số phức thứ nhất: ";
            cin >> sp1.Im;
            cout << "Nhập phần thực của số phức thứ hai: ";
            cin >> sp2.Re;
            cout << "Nhập phần ảo của số phức thứ hai: ";
            cin >> sp2.Im;
            // Kiểm tra xem số phức thứ hai có khác không
    if (sp2.Re != 0 || sp2.Im != 0) {
            // Tính thương của hai số phức
            thuong = THUONGSOPHUC(sp1, sp2, thuong);
            // Xuất thương của hai số phức
        cout << "Thương của hai số phức: " << thuong.Re << " + " << thuong.Im << "i" << endl;
    } else {
        cout << "Không thể chia cho 0." << endl;
    }
            break;
        }
	} while (choice != 0);
}