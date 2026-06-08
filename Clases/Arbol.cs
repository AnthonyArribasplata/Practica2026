using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clases
{
    public class Arbol
    {
        private Nodo raiz_principal = null;

        public void Insertar(Persona p)
        {
            InsertarRecursivo(ref raiz_principal,p);
        }
        private void InsertarRecursivo(ref Nodo raiz,Persona p)
        {
            if (raiz == null)
            {
                Nodo nuevo= new Nodo();
                nuevo.dato = p;

                raiz = nuevo;
                MessageBox.Show("Persona registrada con exito!");
            } else
            {
                if(p < raiz.dato)
                {
                    //izq
                    InsertarRecursivo(ref raiz.izq, p);
                }
                else if (p > raiz.dato)
                {
                    //der
                    InsertarRecursivo(ref raiz.der, p);
                } else
                {
                    MessageBox.Show("Persona ya esta registrada previamente");
                }
            }
        }

        public void Listar(ref ListBox ls)
        {
            ls.Items.Clear();
            InOrdenRecursivo(raiz_principal,ref ls);
        }
        private void InOrdenRecursivo(Nodo raiz,ref ListBox ls)
        {
            if (raiz!=null)
            {
                InOrdenRecursivo(raiz.izq, ref ls);
                ls.Items.Add(raiz.dato);
                InOrdenRecursivo(raiz.der, ref ls);
            }
        }


        public Persona Buscar(int d)
        {
            Persona p= new Persona();
            p.dni = d;

            return BuscarRecursivo(raiz_principal,p);
        }
        private Persona BuscarRecursivo(Nodo raiz, Persona p)
        {
            if (raiz == null)
            {
                //MessageBox.Show("Persona no encontrada!");
                return null;
            }
            else
            {
                if (p < raiz.dato)
                {
                    //izq
                    return BuscarRecursivo(raiz.izq, p);
                }
                else if (p > raiz.dato)
                {
                    //der
                    return BuscarRecursivo(raiz.der, p);
                }
                else
                {
                    //persona encontrada
                    return raiz.dato;
                }
            }
        }

        public Persona BuscarMenor()
        {
            Nodo aux = BuscarMenorRecursivo(raiz_principal);

            return aux.dato;
        }
        private Nodo BuscarMenorRecursivo(Nodo raiz)
        {
            if(raiz.izq != null)
            {
                return BuscarMenorRecursivo(raiz.izq);
            } else
            {
                return raiz;
            }
        }
        public Persona BuscarMayor()
        {
            Nodo aux = BuscarMayorRecursivo(raiz_principal);

            return aux.dato;
        }
        private Nodo BuscarMayorRecursivo(Nodo raiz)
        {
            if (raiz.der != null)
            {
                return BuscarMayorRecursivo(raiz.der);
            }
            else
            {
                return raiz;
            }
        }

        public bool Eliminar(int dni)
        {
            Persona p=new Persona();
            p.dni = dni;

            return EliminarRecursivo(ref raiz_principal,p);
        }
        private bool EliminarRecursivo(ref Nodo raiz,Persona p)
        {
            if (raiz == null)
            {
                //MessageBox.Show("Persona no encontrada!");
                return false;
            }
            else
            {
                if (p < raiz.dato)
                {
                    //izq
                    return EliminarRecursivo(ref raiz.izq, p);
                }
                else if (p > raiz.dato)
                {
                    //der
                    return EliminarRecursivo(ref raiz.der, p);
                }
                else
                {
                    //persona encontrada
                    //Eliminar - PODAR (Eliminar solo hojas)
                    if (raiz.izq==null && raiz.der==null)
                    {
                        raiz = null;
                    }
                    else if (raiz.izq!=null && raiz.der==null)
                    {
                        //sub arbol izq
                        //buscar el elemento mayor
                        Nodo mayor = BuscarMayorRecursivo(raiz.izq);

                        Persona aux=raiz.dato;
                        raiz.dato = mayor.dato;
                        mayor.dato = aux;

                        EliminarRecursivo(ref raiz.izq, p);
                    }
                    else
                    {
                        //sub arbol der
                        //buscar el elemento menor
                        Nodo menor = BuscarMenorRecursivo(raiz.der);

                        Persona aux = raiz.dato;
                        raiz.dato= menor.dato;
                        menor.dato = aux;

                        EliminarRecursivo(ref raiz.der, p);
                    }
                    return true;
                }
            }
        }
    }
}
