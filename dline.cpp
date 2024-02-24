#include <iostream>
#include <list>
using namespace std;
int main()
{
    const int dLineSegment = 39;
    list<int> segmentLengths;
    int length = 0;
    do
    {
        cout << "Enter Segmant Length: ";
        cin >> length;
        if (length == 0)
            continue;
        if (length == -1)
            segmentLengths.pop_back();
        else
            segmentLengths.push_back(length);
        for (auto segmentLength : segmentLengths)
        {
            cout << segmentLength << endl;
        }
    } while (length != 0);
    list<int> segmentRemainders;
    int fullSegments = 0;
    for (auto segmentLength : segmentLengths)
    {
        fullSegments += segmentLength / dLineSegment;
        int segmentRemainder = segmentLength % dLineSegment;
        if (segmentRemainder > 0)
            segmentRemainders.push_back(segmentRemainder);
    }
    cout << "Full Segments: " << fullSegments << endl;
    cout << "Remainder Lengths: " << endl;
    segmentRemainders.sort();
    for (auto segmentRemainder : segmentRemainders)
    {
        cout << segmentRemainder << '"' << endl;
    }
    cout << "Hello, World!" << endl;
    return 0;
}