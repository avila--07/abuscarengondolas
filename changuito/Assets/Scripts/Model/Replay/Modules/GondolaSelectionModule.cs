using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GondolaSelectionModule : Module
{
		public override string Name {
				get { return "GondolaSelection"; }
		}

		public List<Gondola> Gondolas {
				get { return GetList<Gondola> ("glatyp"); }
		}

		public List<Product> ProductsToBuy {
				get { return GetList<Product> ("prods"); }
		}
        
        /// <summary>
        /// Creamos el listado y las gondolas. Damos comienzo a las instancias de juego.
        /// </summary>
		public override void MakeScenario ()
		{
            ListadoSingleton.Instance.makeGondolaScene();            
            this.addListado(ListadoSingleton.Instance.getListado());
            this.addGondolas(ListadoSingleton.Instance.getGondolasSeleccionadas());
        }

		public List<string> GondolaTypes {
				get { return GetList<string> ("glatyp"); }
		}
	/*
		public List<Product> Products {
				get { return GetList<string> ("prods"); }
		}*/
}

        private void addListado(List<GameObject> products)
        {
            foreach(GameObject productOnListado in products)
            {
                Product product = new Product(productOnListado.name, GondolaFactory.getTipoGondola(productOnListado.GetComponent<ProductProperties>().tipo));
                AddProductToBuy(product);
            }
        }

        private void addGondolas(List<int> gondolasSeleccionadas) 
        {
            foreach(int gondolaSeleccionada in gondolasSeleccionadas)
            {
                Gondola gondola = new Gondola(GondolaFactory.getTipoGondola(gondolaSeleccionada));
                AddGondola(gondola);
            }
        }
}
