using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer4Collision
{
    class Sprite
    {
        public Texture2D imagen;
        public Vector2 posicion;
        public Vector2 velocidad = Vector2.Zero;
        Vector2 ventanaTamano = Vector2.Zero;
        float escala = 1.0f;
        SpriteEffects efectos = SpriteEffects.None;
        private SpriteBatch batch;
        public float Escala
        {
            set
            {
                escala = value;
            }
        }
        Vector2 origen = Vector2.Zero;
        public Vector2 Origen
        {
            set
            {
                origen = value;
            }
        }
        public Sprite(GraphicsDeviceManager graficos, Vector2 _posicion)
        {
            this.posicion = _posicion;
            this.batch = new SpriteBatch(graficos.GraphicsDevice);
            this.ventanaTamano = new Vector2(graficos.PreferredBackBufferWidth, graficos.PreferredBackBufferHeight);
        }
        public void cargarImagen(ContentManager contenido, String nombreImagen)
        {
            this.imagen = contenido.Load<Texture2D>(nombreImagen);
        }
        public void Mover()
        {
            posicion.X += velocidad.X;
            posicion.Y += velocidad.Y;
            ColisionPared(ventanaTamano);
        }
        public void ponerPosicion(float x, float y)
        {
            posicion.X = x;
            posicion.Y = y;
        }
        public void Dibujar()
        {
            batch.Begin();
            batch.Draw(imagen, posicion, null, Color.White, 0.0f, origen, new Vector2(escala, escala), efectos, 0.0f);
            batch.End();
        }

        public void ColisionPared(Vector2 Ventana)
        {
            if (posicion.X >= (Ventana.X - imagen.Width))
            {
                // choco con el lado derecho
                velocidad.X = velocidad.X * (-1);
            }
            else if (posicion.X <= 0)
            {
                // choco con el lado izquierdo
                velocidad.X = velocidad.X * (-1);
            }
            else if (posicion.Y >= (Ventana.Y - imagen.Height))
            {
                // choco con la ventana abajo
                velocidad.Y = velocidad.Y * (-1);
            }
            else if (posicion.Y <= 0)
            {
                // choco con la ventana arriba
                velocidad.Y = velocidad.Y * (-1);
            }
        }
    }
}
