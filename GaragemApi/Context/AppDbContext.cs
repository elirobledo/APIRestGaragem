using GaragemApi.Interface;
using GaragemApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GaragemApi.Context
{

    public partial class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public virtual DbSet<CarroModel> Carro { get; set; }
        public virtual DbSet<GaragemModel> Garagem { get; set; }
        public virtual DbSet<PagamentoModel> Pagamento { get; set; }
        public virtual DbSet<TipoEstadiaModel> TipoEstadia { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarroModel>(entity =>
            {
                entity.Property(e => e.Modelo).IsUnicode(false);
                entity.Property(e => e.PlacaCarro).IsUnicode(false);
                entity.Property(e => e.Cor).IsUnicode(false);
                entity.Property(e => e.Ano).IsUnicode(false);
                entity.Property(e => e.OutrasInformacoes).IsUnicode(false);
                entity.Property(e => e.Padrao).IsUnicode(false);
                entity.Property(e => e.IdStatus).IsUnicode(false);
                entity.Property(e => e.IdCarro).ValueGeneratedOnAdd();
                entity.Property(e => e.DataCadastro).IsUnicode(false);
                entity.Property(e => e.DataAtualizacao).IsUnicode(false);
                entity.Property(e => e.DataExclusao).IsUnicode(false);
                entity.Property(e => e.Ativo).IsUnicode(false);
                entity.Property(e => e.IdUsuarioCadastro).IsUnicode(false);
                entity.Property(e => e.IdUsuarioAlteracao).IsUnicode(false);
                entity.Property(e => e.IdUsuarioExclusao).IsUnicode(false);
                entity.Property(e => e.TipoDeVeiculo).IsUnicode(false);
            });

            modelBuilder.Entity<GaragemModel>(entity =>
            {
                entity.Property(e => e.IdGaragem).ValueGeneratedOnAdd();
                entity.Property(e => e.IdTipoEstadia).IsUnicode(false);
                entity.Property(e => e.IdCarro).IsUnicode(false);
                entity.Property(e => e.DataInicio).IsUnicode(false);
                entity.Property(e => e.DataFim).IsUnicode(false);
                entity.Property(e => e.NroVaga).IsUnicode(false);
            });

            modelBuilder.Entity<PagamentoModel>(entity =>
            {
            entity.Property(e => e.IdPagamento).ValueGeneratedOnAdd();
                entity.Property(e => e.ValorEntrada).IsUnicode(false);
                entity.Property(e => e.ValorSaida).IsUnicode(false);
                entity.Property(e => e.ValorMensal).IsUnicode(false);
                entity.Property(e => e.IdCarro).IsUnicode(false);
                entity.Property(e => e.ValorTotal).IsUnicode(false);
                entity.Property(e => e.IdTipoEstadia).IsUnicode(false);
            });

            modelBuilder.Entity<TipoEstadiaModel>(entity =>
            {
                entity.Property(e => e.IdTipoEstadia).ValueGeneratedOnAdd();
                entity.Property(e => e.TipoEstadia).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
