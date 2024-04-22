// Linear Search
#include <stdio.h>
#include <iostream>
using namespace std;

struct node
{
    int data;
    node *next;
};

node *makeNode(int x)
{
    node *newNode = new node();
    newNode->data = x;
    newNode->next = NULL;
    return newNode;
}

void duyet(node *head)
{
    while (head != NULL)
    {
        cout << head->data << " ";
        head = head->next;
    }
}

void addTail(node *&head, int x)
{
    node *newNode = makeNode(x);
    node *temp = head;
    if (head == NULL)
    {
        head = newNode;
        return;
    }
    while (temp->next != NULL)
    {
        temp = temp->next;
    }
    temp->next = newNode;
}

// searching algorithm
node *LinearSearch(node *head, int x)
{
    node *temp = head;
    while (temp != NULL)
    {
        if (temp->data == x)
            break;
        temp = temp->next;
    }
    return temp;
}

node *NodePointer(node *head, int pos)
{
    node *temp = head;
    int index = 0;
    while (index < pos)
    {
        temp = temp->next;
        index++;
    }
    return temp;
}

int GetLength(node *head)
{
    node *temp = head;
    int count = 0;
    while (temp)
    {
        temp = temp->next;
        count++;
    }
    return count;
}

node *BinarySearch(node *head, int x)
{
    int l = 0;
    int r = GetLength(head) - 1;
    while (l <= r)
    {
        int m = (l + r) / 2;
        node *pM = NodePointer(head, m);
        if (pM->data == x)
            return pM;
        if (pM->data > x)
            r = m - 1;
        else
            l = m + 1;
    }
    return NULL;
}

int main()
{
    node *head = NULL;
    int data;
    while (cin >> data)
    {
        if (data < 0)
            break;
        addTail(head, data);
    }
    duyet(head);
    int x;
    cin >> x;
    node *temp = BinarySearch(head, x);
    if (temp != NULL)
    {
        cout << "Tim thay x tai dia chi la: " << temp << endl;
    }
    else
    {
        cout << "Khong tim thay x" << endl;
    }
    return 0;
}