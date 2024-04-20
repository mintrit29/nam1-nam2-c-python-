#include <iostream>
using namespace std;

struct NODE
{
	int Key;
	NODE *pNext;
};
NODE *CreateNode(int Data);
void AddHead(NODE *&pHEAD, int Data);
void AddAfter(NODE *&pHead, int cur, int Data);
void AddTail(NODE *&pHead, int Data);
void PrintList(NODE *pHead);

int main()
{
	// khai bao ds lien ket
	NODE *pHead = NULL;
	// them cac gia tri input vao ds
	int data;
	while (cin >> data)
	{
		AddTail(pHead, data);
	}
	PrintList(pHead);
	// chen them gia tri moi vao sau 1 node trong danh sach

	return 0;
}

NODE *CreateNode(int Data)
{
	NODE *pNode = new NODE;
	pNode->Key = Data;
	pNode->pNext = NULL;
	return pNode;
}
void AddHead(NODE *&pHead, int Data)
{
	NODE *newNode = CreateNode(Data);
	if (pHead == NULL)
	{ // ds chua co phan tu
		pHead = newNode;
	}
	else
	{ // ds da co phan tu
		newNode->pNext = pHead;
		pHead = newNode;
	}
}

void AddAfter(NODE *&pHead, int cur, int Data)
{
	NODE *newNode = CreateNode(Data);
	// 1.tim node co gia tri la cur
	NODE *pNode = pHead;
	while (pNode != NULL)
	{
		if (pNode->Key)
		{
			// tim thay node co gia tri la data
			// 2. chen newNode vao sau pNode
			newNode->pNext = pNode->pNext;
			pNode->pNext = newNode;
		}
		// chua tim thay node co gia tri la cur
		pNode = pNode->pNext;
	}
}

void AddTail(NODE *&pHead, int Data)
{
	NODE *newNode = CreateNode(Data);
	if (pHead == NULL)
		pHead = newNode;
	else
	{
		NODE *pNode = pHead;
		while (pNode->pNext != NULL)
		{
			pNode = pNode->pNext;
		}
		pNode->pNext = newNode;
	}
}

void PrintList(NODE *pHead)
{
	NODE *pNode = pHead;
	while (pNode != NULL)
	{
		cout << pNode->Key << " ";
		// di chuyen pNode qua NODE ke tiep
		pNode = pNode->pNext;
	}
}