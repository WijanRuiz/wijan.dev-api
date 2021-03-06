using Microsoft.EntityFrameworkCore;
namespace api.Models.Context{
    public class Postgre : DbContext{
        public Postgre(){}
        public Postgre(DbContextOptions options):base(options){}
        public DbSet<Brother> brother{get;set;}
        public DbSet<Gender> gender{get;set;}
        public DbSet<Group> group{get;set;}
        public DbSet<GroupType> groupType{get;set;}
        public DbSet<Month> month{get;set;}
        public DbSet<Person> person{get;set;}
        public DbSet<Report> report{get;set;}
        public DbSet<Role> role{get;set;}
        public DbSet<User> user{get;set;}
        protected override void OnModelCreating(ModelBuilder mb){
            mb.HasPostgresExtension("uuid-ossp");
            mb.Entity<Brother>(x => {
                x.ToTable("Brother");
                x.HasKey(y => y.id);
                x.Property(y => y.identifier).HasColumnType("uuid");
                x.HasIndex(y => y.identifier).IsUnique();
            });
            mb.Entity<Gender>(x => {
                x.ToTable("Gender");
                x.HasKey(y => y.id);
                x.Property(y => y.identifier).HasColumnType("uuid");
                x.HasIndex(y => y.identifier).IsUnique();
            });
            mb.Entity<Group>(x => {
                x.ToTable("Group");
                x.HasKey(y => y.id);
                x.Property(y => y.identifier).HasColumnType("uuid");
                x.HasIndex(y => y.identifier).IsUnique();
            });
            mb.Entity<Group_Person>(x => {
                x.ToTable("Group_Person");
                x.HasKey(y => new{y.idGroup, y.idPerson});
                x.HasOne(y => y.group).WithMany(y => y.group_persons).HasForeignKey(y => y.idGroup);
                x.HasOne(y => y.person).WithMany(y => y.group_persons).HasForeignKey(y => y.idPerson);
            });
            mb.Entity<GroupType>(x => {
                x.ToTable("GroupType");
                x.HasKey(y => y.id);
                x.Property(y => y.identifier).HasColumnType("uuid");
                x.HasIndex(y => y.identifier).IsUnique();
            });
            mb.Entity<Month>(x => {
                x.ToTable("Month");
                x.HasKey(y => y.id);
                x.Property(y => y.identifier).HasColumnType("uuid");
                x.HasIndex(y => y.identifier).IsUnique();
            });
            mb.Entity<Person>(x => {
                x.ToTable("Person");
                x.HasKey(y => y.id);
                x.Property(y => y.identifier).HasColumnType("uuid");
                x.HasIndex(y => y.identifier).IsUnique();
            });
            mb.Entity<Report>(x => {
                x.ToTable("Report");
                x.HasKey(y => y.id);
                x.Property(y => y.identifier).HasColumnType("uuid");
                x.HasIndex(y => y.identifier).IsUnique();
            });
            mb.Entity<Role>(x => {
                x.ToTable("Role");
                x.HasKey(y => y.id);
                x.Property(y => y.identifier).HasColumnType("uuid");
                x.HasIndex(y => y.identifier).IsUnique();
            });
            mb.Entity<User>(x => {
                x.ToTable("User");
                x.HasKey(y => y.id);
                x.Property(y => y.identifier).HasColumnType("uuid");
                x.HasIndex(y => y.identifier).IsUnique();
            });
            mb.Entity<User_Role>(x => {
                x.ToTable("User_Role");
                x.HasKey(y => new{y.idRole, y.idUser});
                x.HasOne(y => y.user).WithMany(y => y.user_roles).HasForeignKey(y => y.idUser);
                x.HasOne(y => y.role).WithMany(y => y.user_roles).HasForeignKey(y => y.idRole);
            });
        }
    }
}