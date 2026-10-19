#include <iostream>
#include <cmath>
using namespace std;

class Point {
private:
    double x;
    double y;

public:
    Point() {
        x = 0;
        y = 0;
    }

    Point(double a, double b) {
        x = a;
        y = b;
    }

    void deplace(double dx, double dy) {
        x = x + dx;
        y = y + dy;
    }

    void saisir() {
        cout << "Saisir x et y : ";
        cin >> x >> y;
    }

    void affiche() {
        cout << "(" << x << ", " << y << ")";
    }

    double distance(Point P) {
        double dx = x - P.x;
        double dy = y - P.y;
        return sqrt(dx * dx + dy * dy);
    }

    Point milieu(Point P) {
        double milieuX = (x + P.x) / 2;
        double milieuY = (y + P.y) / 2;
        return Point(milieuX, milieuY);
    }
};
