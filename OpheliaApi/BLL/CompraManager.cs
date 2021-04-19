using DAL.DataContext;
using DAL.DTO;
using DAL.Models;
using DAL.Repository;
using DAL.Repository.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL
{
    public class CompraManager
    {
        private ICompraRepository _compraRepository;
        private IProductoRepository _productoRepository;

        public CompraManager(ApplicationDbContext context)
        {
            _compraRepository = new CompraRepository(context);
            _productoRepository = new ProductoRepository(context);
        }

        public async Task<IList<FacturacionCompraDTO>> GetAll()
        {
            try
            {
                List <FacturacionCompraDTO> facturacionesCompras = await _compraRepository.FindAll()
                    .Include(cliente => cliente.IdClienteNavigation).ThenInclude(tipo => tipo.IdTipoDocumentoNavigation)
                    .Include(compraProducto => compraProducto.CompraProductos).ThenInclude(producto => producto.IdProductoNavigation).
                    Select( compra => new FacturacionCompraDTO
                {
                    IdCompra = compra.IdCompra,
                    CantidadProductos = compra.CompraProductos.Sum(p => p.Cantidad),
                    FechaCompra = compra.Fecha.ToString("dd MMMM yyyy"),
                    ValorCompra = compra.CompraProductos.Sum(p => p.IdProductoNavigation.Precio),
                    Cliente = new ClienteDTO()
                    {
                        IdCliente = compra.IdCliente,
                        Apellido = compra.IdClienteNavigation.Apellido,
                        Nombre = compra.IdClienteNavigation.Nombre,
                        Documento = compra.IdClienteNavigation.Documento,
                        IdTipoDocumento = compra.IdClienteNavigation.IdTipoDocumento,
                        TipoDocumento = compra.IdClienteNavigation.IdTipoDocumentoNavigation.Nombre
                    }
                }).ToListAsync();

                return facturacionesCompras;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<FacturacionCompraDTO> Find(int id)
        {
            try
            {
                FacturacionCompraDTO facturacionCompra = await _compraRepository.FindByCondition(x => x.IdCompra == id)
                    .Include(cliente => cliente.IdClienteNavigation).ThenInclude(tipoDoc => tipoDoc.IdTipoDocumentoNavigation)
                    .Include(compra => compra.CompraProductos).ThenInclude(producto => producto.IdProductoNavigation)
                    .Select(compra => new FacturacionCompraDTO
                    {
                        IdCompra = compra.IdCompra,
                        CantidadProductos = compra.CompraProductos.Sum(p => p.Cantidad),
                        ValorCompra = compra.CompraProductos.Sum(p => p.IdProductoNavigation.Precio),
                        FechaCompra = compra.Fecha.ToString("dd MMMM yyyy"),
                        Cliente = new ClienteDTO()
                        {
                            IdCliente = compra.IdCliente,
                            Apellido = compra.IdClienteNavigation.Apellido,
                            Nombre = compra.IdClienteNavigation.Nombre,
                            Documento = compra.IdClienteNavigation.Documento,
                            Edad = DateTime.Now.Year - compra.IdClienteNavigation.FechaNacimiento.Year,
                            IdTipoDocumento = compra.IdClienteNavigation.IdTipoDocumento,
                            TipoDocumento = compra.IdClienteNavigation.IdTipoDocumentoNavigation.Nombre
                        },
                        Productos = compra.CompraProductos.Select(p => new ProductoDTO
                        {
                            IdProducto = p.IdProducto,
                            Nombre = p.IdProductoNavigation.Nombre,
                            Descripcion = p.IdProductoNavigation.Descripcion,
                            EstaActivo = p.IdProductoNavigation.EstaActivo.Value,
                            Precio = p.IdProductoNavigation.Precio,
                            Cantidad = p.Cantidad
                        }).ToList()
                    }).FirstOrDefaultAsync();


                return facturacionCompra;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int Create(FacturacionCompraDTO facturacionCompra)
        {
            try
            {
                Compra compra = new Compra();
                compra.IdCliente = facturacionCompra.Cliente.IdCliente;
                compra.Fecha = DateTime.Now;

                foreach(var producto in facturacionCompra.Productos)
                {
                    compra.CompraProductos.Add(new CompraProducto
                    {
                        Cantidad = producto.Cantidad,
                        IdProducto = producto.IdProducto
                    });
                }
                _compraRepository.Create(compra);
                _compraRepository.Save();

                return compra.IdCompra;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Update(FacturacionCompraDTO facturacionCompra)
        {
            try
            {
                Compra compra = await _compraRepository.FindAsync(facturacionCompra.IdCompra);

                if(compra != null)
                {
                    compra.IdCliente = facturacionCompra.Cliente.IdCliente;
                    List<CompraProducto> compraProductos = new List<CompraProducto>();
                    foreach (var producto in facturacionCompra.Productos)
                    {
                        compraProductos.Add(new CompraProducto
                        {
                            IdCompra = compra.IdCompra,
                            Cantidad = producto.Cantidad,
                            IdProducto = producto.IdProducto
                        });
                    }

                    compra.CompraProductos = compraProductos;

                    _compraRepository.Update(compra);
                    _compraRepository.Save();
                }
                else
                {
                    throw new Exception("No existe la compra");
                }
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                Compra compra = await _compraRepository.FindAsync(id);

                if (compra != null)
                {
                    _compraRepository.Delete(compra);
                    _compraRepository.Save();
                }
                else
                {
                    throw new Exception("No existe la compra");
                }
               
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
