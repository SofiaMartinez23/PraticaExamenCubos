using Microsoft.EntityFrameworkCore;
using PraticaExamen.Data;
using PraticaExamen.Models;

namespace PraticaExamen.Repositories
{
    #region
    /*
    	CREATE OR ALTER VIEW VISTACOMPRAS AS
        SELECT 
            c.id_pedido AS IDVISTACOMPRA,            
            c.id_usuario AS IdUsuario,            
            u.nombre AS NombreUsuario,                  
            c.id_cubo AS IdCubo,                     
            cubo.nombre AS NombreCubo,                
            cubo.precio AS PrecioCubo,                  
            cubo.imagen AS ImagenCubo,                
            c.cantidad AS Cantidad,                     
            c.fecha AS FechaCompra,                      
            (c.cantidad * cubo.precio) AS PrecioFinal    
        FROM 
            COMPRA c
        JOIN 
            CUBOS cubo ON c.id_cubo = cubo.id_cubo     
        JOIN 
            USUARIOS u ON c.id_usuario = u.id_user;  
     */
    #endregion
    public class RepositoryCubos
    {
        private CubosContext context;

        public RepositoryCubos(CubosContext context)
        {
            this.context = context;
        }

        public async Task<List<Cubo>> GetCubosAsync()
        {
            return await this.context.Cubos.ToListAsync();
        }
        public async Task<List<Marca>> GetMarcaAsync()
        {
            return await this.context.Marcas.ToListAsync();
        }

        public async Task<List<Cubo>> GetCubosByMarcaAsync(int idmarca)
        {
            return await this.context.Cubos
                .Where(c => c.IdMarca == idmarca)
                .ToListAsync();
        }

        public async Task<Cubo> FindCuboAsync(int idcubo)
        {
            return await this.context.Cubos
                .FirstOrDefaultAsync(c => c.IdCubo == idcubo);
        }

        public async Task<Usuario> FindUsuarioAsync(int idusuario)
        {
            return await this.context.Usuarios
                .FirstOrDefaultAsync(u => u.IdUsuario == idusuario);
        }

        public async Task<Usuario> LoginUsuarioAsync(string email, string password)
        {
            return await this.context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

        public async Task<List<Cubo>> GetCubosCompraAsync(List<int> compra)
        {
            return await this.context.Cubos
                .Where(c => compra.Contains(c.IdCubo))
                .ToListAsync();
        }

        public async Task<int> GetMaxIdCompraAsync()
        {
            if (this.context.Compras.Count() == 0) return 1;
            else return await this.context.Compras
                    .MaxAsync(c => c.IdCompra) + 1;
        }


        public async Task FinalizarCompraAsync(List<int> carrito, int idusuario)
        {
            int idcompra = await GetMaxIdCompraAsync();
            DateTime fecha = DateTime.Now;
            foreach (int idcubo in carrito.Distinct())
            {
                await this.context.Compras.AddAsync(new Compra
                {
                    IdCompra = idcompra,
                    IdCubo = idcubo,
                    FechaPedido = fecha,
                    PrecioFinal = carrito.Count(id => id == idcubo) * (await FindCuboAsync(idcubo)).Precio,
                    IdUsuario = idusuario
                });
                await this.context.SaveChangesAsync();
            }
        }

        // Obtener los pedidos realizados por el usuario
        public async Task<List<VistaCompra>> GetPedidosUsuarioAsync(int idusuario)
        {
            return await this.context.VistaCompras
                .Where(vc => vc.IdUsuario == idusuario)
                .ToListAsync();
        }

        // Obtener la vista de compras similar a VistaPedidos para los cubos
        public async Task<List<VistaCompra>> GetVistaComprasAsync(int idusuario)
        {
            return await this.context.VistaCompras
                .Where(vc => vc.IdUsuario == idusuario)
                .ToListAsync();
        }

        // Método para obtener la cantidad de cubos en el carrito
        public async Task<List<Cubo>> GetCubosCarritoAsync(List<int> carrito)
        {
            return await this.context.Cubos
                .Where(c => carrito.Contains(c.IdCubo))
                .ToListAsync();
        }
    }
}
