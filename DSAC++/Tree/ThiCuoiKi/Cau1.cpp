#include <iostream>
#include <stdio.h>
#include <string>
#include <ctime>
#include <sstream>
#include <vector>

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
    Node *leftChild;
    Node *rightChild;
};

void AddPerson(Node *&root, PERSON newPerson, string parentName)
{
    if (root == NULL)
    {
        root = new Node{newPerson, NULL, NULL};
        return;
    }

    if (root->data.Name == parentName)
    {
        if (root->leftChild == NULL)
        {
            root->leftChild = new Node{newPerson, NULL, NULL};
        }
        else if (root->rightChild == NULL)
        {
            root->rightChild = new Node{newPerson, NULL, NULL};
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

void InThongTinNguoi(const PERSON &person)
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
        tm *ltm = localtime(&now);
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
void PrintFamilyTree(Node *root, int level = 0)
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
Node *TimKiemNguoi(Node *root, const string &name, int &level)
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
    Node *found = TimKiemNguoi(root->leftChild, name, level);
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

// Hàm main
int main()
{
    Node *familyTree = NULL;

    int choice;
    do
    {
        cout << "\nMENU QUAN LY GIA PHA:\n";
        cout << "1. Them thanh vien\n";
        cout << "2. Tim kiem thanh vien\n";
        cout << "3. In gia pha\n";
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
            Node *found = TimKiemNguoi(familyTree, searchName, searchLevel);
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
        case 0:
            cout << "Tam biet!" << endl;
            break;
        default:
            cout << "Lua chon khong hop le. Vui long nhap lai." << endl;
        }
    } while (choice != 0);

    return 0;
}