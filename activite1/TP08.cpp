#include <iostream>
using namespace std;

class Rectangle {
private:
    double largeur;
    double hauteur;

public:
    Rectangle(double l, double h) {
        largeur = l;
        hauteur = h;
    }

    double perimetre() {
        return 2 * (largeur + hauteur);
    }

    double surface() {
        return largeur * hauteur;
    }

    void afficher() {
        cout << "Largeur : " << largeur << "\n";
        cout << "Hauteur : " << hauteur << "\n";
        cout << "Perimetre : " << perimetre() << "\n";
        cout << "Surface : " << surface() << "\n";
    }

    double lireLargeur() {
        return largeur;
    }

    double lireHauteur() {
        return hauteur;
    }

    void modifierLargeur(double l) {
        largeur = l;
    }

    void modifierHauteur(double h) {
        hauteur = h;
    }
};

int main() {
    double l, h;

    cout << "Largeur et hauteur : ";
    cin >> l >> h;

    Rectangle r(l, h);
    r.afficher();

    return 0;
}
