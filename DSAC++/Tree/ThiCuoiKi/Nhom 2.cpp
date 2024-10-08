﻿#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <stdio.h>
#include <string>
#include <ctime>
#include <sstream>
#include <vector>
#include <unordered_map>
using namespace std;

struct PERSON
{
    string Name;
    string Gender;
    string BirthPlace;
    string DateOfBirth;
    string DateOfDeath;
    string Job;
};

struct Node
{
    PERSON data;
    Node* leftChild;
    Node* rightChild;
};

void AddPerson(Node*& root, PERSON newPerson, string parentName)
{
    if (root == NULL)
    {
        root = new Node{ newPerson, NULL, NULL };
        return;
    }

    if (root->data.Name == parentName)
    {
        if (root->leftChild == NULL)
        {
            root->leftChild = new Node{ newPerson, NULL, NULL };
        }
        else if (root->rightChild == NULL)
        {
            root->rightChild = new Node{ newPerson, NULL, NULL };
        }
        else
        {
            cout << "Parent already has two children." << endl;
        }
        return;
    }
    else
    {
        if (root->leftChild != NULL)
        {
            AddPerson(root->leftChild, newPerson, parentName);
        }
        if (root->rightChild != NULL)
        {
            AddPerson(root->rightChild, newPerson, parentName);
        }
    }
}

PERSON NhapThongTinNguoi()
{
    PERSON person;
    cout << "Nhap ho va ten: ";
    getline(cin >> ws, person.Name);
    cout << "Nhap gioi tinh (Nam/Nu): ";
    getline(cin, person.Gender);
    cout << "Nhap noi sinh: ";
    getline(cin, person.BirthPlace);
    cout << "Nhap ngay sinh (dd/mm/yyyy): ";
    getline(cin, person.DateOfBirth);
    cout << "Nhap ngay mat (dd/mm/yyyy, bo trong neu con song): ";
    getline(cin, person.DateOfDeath);
    cout << "Nhap nghe nghiep: ";
    getline(cin, person.Job);
    return person;
}

void InThongTinNguoi(const PERSON& person)
{
    cout << "\n- Ho va ten: " << person.Name << endl;
    cout << "- Gioi tinh: " << person.Gender << endl;
    cout << "- Noi sinh: " << person.BirthPlace << endl;
    cout << "- Ngay sinh: " << person.DateOfBirth << endl;

    // Tính tuổi
    int yearOfBirth, monthOfBirth, dayOfBirth;
    sscanf(person.DateOfBirth.c_str(), "%d/%d/%d", &dayOfBirth, &monthOfBirth, &yearOfBirth);

    int age;
    if (person.DateOfDeath.empty())
    { // Trường hợp còn sống
        time_t now = time(0);
        tm* ltm = localtime(&now);
        int currentYear = 1900 + ltm->tm_year;
        age = currentYear - yearOfBirth;
    }
    else
    { // Trường hợp đã mất
        int yearOfDeath, monthOfDeath, dayOfDeath;
        sscanf(person.DateOfDeath.c_str(), "%d/%d/%d", &dayOfDeath, &monthOfDeath, &yearOfDeath);
        age = yearOfDeath - yearOfBirth;

        // Xử lý trường hợp tháng sinh sau tháng mất
        if (monthOfBirth > monthOfDeath || (monthOfBirth == monthOfDeath && dayOfBirth > dayOfDeath))
        {
            age--;
        }
    }

    cout << "- Tuoi: " << age << endl;

    if (!person.DateOfDeath.empty())
    {
        cout << "- Tinh trang: Da mat" << endl;
    }
    else
    {
        cout << "- Tinh trang: Con song" << endl;
    }
    cout << "- Nghe nghiep: " << person.Job << endl;
}

// Hàm duyệt cây gia phả theo thứ tự NLR và in thông tin
void PrintFamilyTree(Node* root, int level = 0)
{
    if (root != NULL)
    {
        for (int i = 0; i < level; i++)
        {
            cout << "  ";
        }
        InThongTinNguoi(root->data);
        PrintFamilyTree(root->leftChild, level + 1);
        PrintFamilyTree(root->rightChild, level + 1);
    }
}

// Hàm tìm kiếm người trong cây gia phả
Node* TimKiemNguoi(Node* root, const string& name, int& level)
{
    if (root == NULL)
    {
        return NULL;
    }

    if (root->data.Name == name)
    {
        return root;
    }

    // Tìm kiếm trong cây con trái
    Node* found = TimKiemNguoi(root->leftChild, name, level);
    if (found != NULL)
    {
        level++; // Tăng level nếu tìm thấy trong cây con trái
        return found;
    }

    // Tìm kiếm trong cây con phải
    found = TimKiemNguoi(root->rightChild, name, level);
    if (found != NULL)
    {
        level++; // Tăng level nếu tìm thấy trong cây con phải
        return found;
    }

    return NULL; // Không tìm thấy
}

int CalculateAge(const string& dateOfBirth, const string& currentDate)
{
    int birthDay, birthMonth, birthYear;
    int currentDay, currentMonth, currentYear;

    sscanf(dateOfBirth.c_str(), "%d/%d/%d", &birthDay, &birthMonth, &birthYear);
    sscanf(currentDate.c_str(), "%d/%d/%d", &currentDay, &currentMonth, &currentYear);

    int age = currentYear - birthYear;
    if (currentMonth < birthMonth || (currentMonth == birthMonth && currentDay < birthDay))
    {
        age--;
    }
    return age;
}

int TongSoTuoi(Node* root, const string& currentDate)
{
    if (root == NULL)
    {
        return 0;
    }
    int totalAge = 0;
    if (root->data.DateOfDeath.empty()) // Chỉ tính tuổi nếu người này còn sống
    {
        totalAge += CalculateAge(root->data.DateOfBirth, currentDate);
    }
    totalAge += TongSoTuoi(root->leftChild, currentDate);
    totalAge += TongSoTuoi(root->rightChild, currentDate);
    return totalAge;
}

void InThanhVienChuaCoCon(Node* root)
{
    if (root == NULL)
    {
        return;
    }
    if (root->leftChild == NULL && root->rightChild == NULL)
    {
        InThongTinNguoi(root->data);
    }
    InThanhVienChuaCoCon(root->leftChild);
    InThanhVienChuaCoCon(root->rightChild);
}

// cau6
void InThanhVienThuN(Node* root, int N, int currentLevel = 1)
{
    if (root != NULL)
    {
        if (currentLevel == N)
        {
            cout << " - " << root->data.Name << endl;
        }
        InThanhVienThuN(root->leftChild, N, currentLevel + 1);
        InThanhVienThuN(root->rightChild, N, currentLevel + 1);
    }
}

// cau7
bool CompareDates(const string& date1, const string& date2)
{
    int year1 = stoi(date1.substr(6));
    int year2 = stoi(date2.substr(6));

    if (year1 != year2)
    {
        return year1 > year2;
    }
    else
    {
        int month1 = stoi(date1.substr(3, 2));
        int month2 = stoi(date2.substr(3, 2));
        if (month1 != month2)
        {
            return month1 > month2;
        }
        else
        {
            int day1 = stoi(date1.substr(0, 2));
            int day2 = stoi(date2.substr(0, 2));
            return day1 > day2;
        }
    }
}

void CollectAliveMembers(Node* root, vector<PERSON>& aliveMembers)
{
    if (root != NULL)
    {
        if (root->data.DateOfDeath.empty())
        {
            aliveMembers.push_back(root->data);
        }
        CollectAliveMembers(root->leftChild, aliveMembers);
        CollectAliveMembers(root->rightChild, aliveMembers);
    }
}

void SortAliveMembersByAge(vector<PERSON>& aliveMembers)
{
    for (int i = 1; i < aliveMembers.size(); i++)
    {
        PERSON key = aliveMembers[i];
        int j = i - 1;

        while (j >= 0 && CompareDates(aliveMembers[j].DateOfBirth, key.DateOfBirth))
        {
            aliveMembers[j + 1] = aliveMembers[j];
            j = j - 1;
        }
        aliveMembers[j + 1] = key;
    }
}

void PrintAliveMembersSortedByAge(Node* root)
{
    if (root == NULL)
    {
        return;
    }

    vector<PERSON> aliveMembers;
    CollectAliveMembers(root, aliveMembers);
    SortAliveMembersByAge(aliveMembers);

    for (const auto& person : aliveMembers)
    {
        InThongTinNguoi(person);
    }
}
void DuyetCayNLR(Node* root)
{
    if (root != NULL)
    {
        InThongTinNguoi(root->data);
        DuyetCayNLR(root->leftChild);
        DuyetCayNLR(root->rightChild);
    }
}

Node* TimKiemNguoi(Node* root, const string& name)
{
    if (root == NULL)
    {
        return NULL;
    }
    if (root->data.Name == name)
    {
        return root;
    }
    Node* found = TimKiemNguoi(root->leftChild, name);
    if (found != NULL)
    {
        return found;
    }
    return TimKiemNguoi(root->rightChild, name);
}

void ThongKeGioiTinh(Node* root, int& maleCount, int& femaleCount)
{
    if (root != NULL)
    {
        if (root->data.Gender == "Nam")
        {
            maleCount++;
        }
        else if (root->data.Gender == "Nu")
        {
            femaleCount++;
        }
        ThongKeGioiTinh(root->leftChild, maleCount, femaleCount);
        ThongKeGioiTinh(root->rightChild, maleCount, femaleCount);
    }
}

void ThongKeNgheNghiep(Node* root, unordered_map<string, int>& jobCount)
{
    if (root != NULL)
    {
        jobCount[root->data.Job]++;
        ThongKeNgheNghiep(root->leftChild, jobCount);
        ThongKeNgheNghiep(root->rightChild, jobCount);
    }
}

string TimNgheNhieuNhat(unordered_map<string, int>& jobCount)
{
    string mostCommonJob = "";
    int maxCount = 0;

    for (const auto& job : jobCount)
    {
        if (job.second > maxCount)
        {
            mostCommonJob = job.first;
            maxCount = job.second;
        }
    }

    return mostCommonJob;
}

void XoaCay(Node*& root)
{
    if (root != NULL)
    {
        XoaCay(root->leftChild);
        XoaCay(root->rightChild);
        delete root;
        root = NULL;
    }
}

// Hàm tìm kiếm người trong cây gia phả và trả về node cha
Node* FindParentNode(Node* root, const string& name, Node*& parent)
{
    if (root == NULL)
    {
        return NULL;
    }

    if (root->data.Name == name)
    {
        return root;
    }

    // Tìm kiếm trong cây con trái
    Node* found = FindParentNode(root->leftChild, name, parent);
    if (found != NULL)
    {
        return found; // Tìm thấy trong cây con trái, không cần tìm kiếm bên phải
    }

    // Tìm kiếm trong cây con phải
    found = FindParentNode(root->rightChild, name, parent);
    if (found != NULL)
    {
        return found;
    }

    parent = root; // Cập nhật node cha nếu không tìm thấy trong con cháu
    return NULL; // Không tìm thấy
}

void XoaThanhVien(Node*& root, const string& nameToDelete)
{
    if (root == NULL) {
        return; // Base case: empty tree
    }

    // Search for the person and its parent
    Node* parent = NULL;
    Node* current = FindParentNode(root, nameToDelete, parent);

    if (current != NULL) {
        // Delete entire subtree rooted at 'current' (including descendants)
        if (parent != NULL) {
            if (parent->leftChild == current) {
                parent->leftChild = NULL;
            }
            else if (parent->rightChild == current) {
                parent->rightChild = NULL;
            }
        }
        else {
            root = NULL; // If deleting root
        }
        XoaCay(current);
        cout << "Da xoa thanh vien " << nameToDelete << " va tat ca con chau." << endl;
    }
    else {
        cout << "Khong tim thay thanh vien can xoa." << endl;
    }
}


// Hàm main
int main()
{
    Node* familyTree = NULL;

    int choice;
    do
    {
        cout << "\nMENU QUAN LY GIA PHA:\n";
        cout << "1. Them thanh vien\n";
        cout << "2. Tim kiem thanh vien\n";
        cout << "3. In gia pha\n";
        cout << "4. Tinh tong so tuoi cua cac thanh vien con song\n";
        cout << "5. In cac thanh vien chua co con\n";
        cout << "6. In danh sach thanh vien thu N\n";
        cout << "7. In danh sach thanh vien con song theo tuoi\n";
        cout << "8. Thong ke gioi tinh\n";
        cout << "9. Thong ke nghe nghiep\n";
        cout << "10. Xoa thanh vien\n";
        cout << "0. Thoat\n";
        cout << "Nhap lua chon cua ban: ";
        cin >> choice;

        switch (choice)
        {
        case 1:
        {
            PERSON newPerson = NhapThongTinNguoi();
            string parentName = "";

            cout << "Nhap ten cha/me (nhap 'q' de bo qua neu la goc): ";
            getline(cin >> ws, parentName);

            if (parentName != "q")
            {
                int parentLevel = 0;
                while (TimKiemNguoi(familyTree, parentName, parentLevel) == NULL)
                {
                    cout << "Khong tim thay cha/me. Vui long nhap lai (hoac 'q' de bo qua): ";
                    getline(cin >> ws, parentName);
                    if (parentName == "q")
                    {
                        break;
                    }
                }
            }
            else
            {
                parentName = "";
            }
            int newPersonLevel = 0;
            while (TimKiemNguoi(familyTree, newPerson.Name, newPersonLevel) != NULL)
            {
                cout << "Ten da ton tai. Vui long nhap lai ho va ten: ";
                getline(cin >> ws, newPerson.Name);
            }

            AddPerson(familyTree, newPerson, parentName);
            break;
        }
        case 2:
        {
            string searchName;
            cout << "Nhap ten nguoi can tim: ";
            getline(cin >> ws, searchName);
            int searchLevel = 0;
            Node* found = TimKiemNguoi(familyTree, searchName, searchLevel);
            if (found != NULL)
            {
                InThongTinNguoi(found->data);
                cout << "- Thuoc doi thu: " << searchLevel + 1 << endl;
            }
            else
            {
                cout << "Khong tim thay nguoi nay trong gia pha." << endl;
            }
            break;
        }
        case 3:
            PrintFamilyTree(familyTree);
            break;

        case 4:
        {
            // Giả sử ngày hiện tại là "29/05/2024"
            string currentDate = "29/05/2024";
            int totalAge = TongSoTuoi(familyTree, currentDate);
            cout << "Tong so tuoi cua cac thanh vien con song: " << totalAge << endl;
            break;
        }
        case 5:
        {
            {
                InThanhVienChuaCoCon(familyTree);
                break;
            }
        }
        case 6:
        {
            int N;
            cout << "Nhap so nguyen N: ";
            cin >> N;
            cin.ignore();
            cout << "\nDanh sach thanh vien thu " << N << ":\n";
            InThanhVienThuN(familyTree, N);
            break;
        }
        case 7:
            cout << "\nDanh sach thanh vien con song (sap xep theo tuoi):\n";
            PrintAliveMembersSortedByAge(familyTree);
            break;

        case 8:
        {
            int maleCount = 0;
            int femaleCount = 0;
            ThongKeGioiTinh(familyTree, maleCount, femaleCount);
            cout << "So luong thanh vien Nam: " << maleCount << endl;
            cout << "So luong thanh vien Nu: " << femaleCount << endl;
            break;
        }
        case 9:
        {
            unordered_map<string, int> jobCount;
            ThongKeNgheNghiep(familyTree, jobCount);
            cout << "Thong ke nghe nghiep cua cac thanh vien:\n";
            for (const auto& job : jobCount)
            {
                cout << "- " << job.first << ": " << job.second << " thanh vien\n";
            }
            string mostCommonJob = TimNgheNhieuNhat(jobCount);
            if (!mostCommonJob.empty())
            {
                cout << "Nghe nghiep co nhieu thanh vien nhat: " << mostCommonJob << endl;
            }
            break;
        }
        case 10:
        {
            string nameToDelete;
            cout << "Nhap ten thanh vien can xoa: ";
            getline(cin >> ws, nameToDelete);
            XoaThanhVien(familyTree, nameToDelete);
            break;
        }
        case 0:
            cout << "Thoat chuong trinh." << endl;
            break;
        default:
            cout << "Lua chon khong hop le. Vui long chon lai." << endl;
            break;
        }
    } while (choice != 0);


    XoaCay(familyTree);
    return 0;
}