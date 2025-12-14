/* using System;
using Unity.Cinemachine;

namespace DefaultNamespace
{
    public class Personnages 
    {
        private string nom;
        private int pv;
        private int damage;

        public Personnages()
        {
            nom = "Chevalier";
            pv = 10;
            damage = 2;
        }

        public String getNom()
        {
            return nom;
        }

        public int getPv()
        {
            return pv;
        }

        public int getDamage()
        {
            return damage;
        }

        public void setNom(String nom)
        {
            this.nom = nom;
        }

        public void setPv(int pv)
        {
            this.pv = pv;
        }

        public void setDamage(int damage)
        {
            this.damage = damage;
        }

        public void Attack(Enemy e)
        {
            e.setPv(e.getPv() - this.damage);
        }


    }
}*/