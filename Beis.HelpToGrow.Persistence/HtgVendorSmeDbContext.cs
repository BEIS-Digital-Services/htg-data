

#nullable disable

using Beis.HelpToGrow.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
namespace Beis.HelpToGrow.Persistence
{
    public partial class HtgVendorSmeDbContext : DbContext, IDataProtectionKeyContext
    {
        public HtgVendorSmeDbContext()
        {
        }

        public HtgVendorSmeDbContext(DbContextOptions<HtgVendorSmeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DataProtectionKey> DataProtectionKeys { get; set; }
        public virtual DbSet<additional_cost> additional_costs { get; set; }
        public virtual DbSet<additional_cost_desc> additional_cost_descs { get; set; }
        public virtual DbSet<additional_cost_type> additional_cost_types { get; set; }        
        public virtual DbSet<eligibility_check_result> eligibility_check_results { get; set; }
        public virtual DbSet<enterprise> enterprises { get; set; }
        public virtual DbSet<enterprise_eligibility_status> enterprise_eligibility_statuses { get; set; }
        public virtual DbSet<enterprise_size> enterprise_sizes { get; set; }
        public virtual DbSet<free_trial_end_action> free_trial_end_actions { get; set; }
        public virtual DbSet<fcasociety> fcasocieties { get; set; }
        public virtual DbSet<indesser_api_call_status> indesser_api_call_statuses { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<product_capability> product_capabilities { get; set; }
        public virtual DbSet<product_filter> product_filters { get; set; }
        public virtual DbSet<product_price> product_prices { get; set; }
        public virtual DbSet<product_price_base_description> product_price_base_descriptions { get; set; }
        public virtual DbSet<product_price_base_metric_price> product_price_base_metric_prices { get; set; }
        public virtual DbSet<product_price_secondary_description> product_price_secondary_descriptions { get; set; }
        public virtual DbSet<product_price_secondary_metric> product_price_secondary_metrics { get; set; }
        public virtual DbSet<product_status> product_statuses { get; set; }
        public virtual DbSet<settings_category_type> settings_category_types { get; set; }
        public virtual DbSet<settings_licence_type> settings_licence_types { get; set; }
        public virtual DbSet<settings_product_capability> settings_product_capabilities { get; set; }
        public virtual DbSet<settings_product_filter> settings_product_filters { get; set; }
        public virtual DbSet<settings_product_filters_category> settings_product_filters_categories { get; set; }
        public virtual DbSet<settings_product_type> settings_product_types { get; set; }
        public virtual DbSet<settings_project> settings_projects { get; set; }
        public virtual DbSet<token> tokens { get; set; }
        public virtual DbSet<token_reconciliation_status> token_reconciliation_statuses { get; set; }
        public virtual DbSet<token_redemption_status> token_redemption_statuses { get; set; }
        public virtual DbSet<vendor_api_call_status> vendor_api_call_statuses { get; set; }
        public virtual DbSet<vendor_reconciliation> vendor_reconciliations { get; set; }
        public virtual DbSet<user_discount> user_discounts { get; set; }
        public virtual DbSet<vendor_company> vendor_companies { get; set; }
        public virtual DbSet<vendor_company_user> vendor_company_users { get; set; }
        public virtual DbSet<vendor_reconciliation_sale> vendor_reconciliation_sales { get; set; }
        public virtual DbSet<vendor_status> vendor_statuses { get; set; }

        public virtual DbSet<companies_house_api_result> companies_house_api_result { get; set; }

        public virtual DbSet<token_cancellation_status> token_cancellation_status { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<additional_cost>(entity =>
            {
                entity.HasKey(e => e.additional_cost_id);

                entity.ToTable("additional_cost");

                entity.Property(e => e.additional_cost_freq).HasMaxLength(200);

                entity.HasOne(d => d.additional_cost_desc)
                    .WithMany(p => p.additional_costs)
                    .HasForeignKey(d => d.additional_cost_desc_id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.product_price)
                    .WithMany(p => p.additional_costs)
                    .HasForeignKey(d => d.product_price_id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.additional_cost_type)
                    .WithMany(p => p.additional_costs)
                    .HasForeignKey(d => d.additional_cost_type_id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<additional_cost_desc>(entity =>
            {
                entity.HasKey(e => e.additional_cost_desc_id);

                entity.ToTable("additional_cost_desc");

                entity.Property(e => e.additional_costDesc).HasMaxLength(5000);
            });

            modelBuilder.Entity<additional_cost_type>(entity =>
            {
                entity.HasKey(e => e.additional_cost_type_id);

                entity.ToTable("additional_cost_type");

                entity.Property(e => e.description).HasMaxLength(256);
            });

            modelBuilder.Entity<eligibility_check_result>(entity =>
            {
                entity.HasKey(e => e.eligibility_check_result_id);

                entity.ToTable("eligibility_check_result");

                entity.Property(e => e.result_object).IsRequired();

                entity.HasOne(e => e.indesser_api_call_status)
                    .WithOne(e => e.eligibility_check_result)
                    .HasForeignKey<eligibility_check_result>(e => e.call_id)
                    .HasConstraintName("FK_eligibility_check_result_indesser_api_call_status");
            });

            modelBuilder.Entity<enterprise>(entity =>
            {
                entity.HasKey(e => e.enterprise_id);

                entity.ToTable("enterprise");

                entity.HasIndex(e => e.companies_house_no, "IX_enterprise_companies_house_no")
                    .IsUnique();

                entity.HasIndex(e => e.fca_no, "IX_enterprise_fca_no")
                    .IsUnique();

                entity.Property(e => e.applicant_email_address).IsRequired();

                entity.Property(e => e.applicant_name).IsRequired();

                entity.Property(e => e.applicant_role).IsRequired();

                entity.Property(e => e.enterprise_name).IsRequired();

                entity.HasOne(d => d.indesser_api_call_status)
                    .WithOne(_ => _.enterprise)               
                    .HasForeignKey<enterprise>()
                    .HasConstraintName("FK_enterprise_indesser_api_call_status");
            });

            modelBuilder.Entity<enterprise_eligibility_status>(entity =>
            {
                entity.HasKey(e => e.eligibility_status_id);

                entity.ToTable("enterprise_eligibility_status");

                entity.Property(e => e.eligibility_status_desc).IsRequired();
            });

            modelBuilder.Entity<enterprise_size>(entity =>
            {
                entity.HasKey(e => e.enterprise_size_id);

                entity.ToTable("enterprise_size");

                entity.Property(e => e.enterprise_size_desc).IsRequired();
            });

            modelBuilder.Entity<fcasociety>(entity =>
            {
                entity.HasKey(e => e.societyId);

                entity.ToTable("fcasociety");
            });

            modelBuilder.Entity<free_trial_end_action>(entity =>
            {
                entity.HasKey(e => e.free_trial_end_action_id);

                entity.ToTable("free_trial_end_action");

                entity.Property(e => e.free_trial_end_action_desc).HasMaxLength(5000);
            });

            modelBuilder.Entity<indesser_api_call_status>(entity =>
            {
                entity.HasKey(e => e.call_id);

                entity.ToTable("indesser_api_call_status");

                entity.Property(e => e.result).IsRequired();

                entity.HasOne(e => e.enterprise)
                    .WithOne(e => e.indesser_api_call_status)
                    .HasForeignKey<indesser_api_call_status>(e => e.enterprise_id)
                    .HasConstraintName("FK_indesser_api_call_status_enterprise");
            });

            modelBuilder.Entity<product>(entity =>
            {
                entity.HasKey(e => e.product_id);

                entity.Property(e => e.column23).HasMaxLength(1);

                entity.Property(e => e.customer_base).HasMaxLength(5000);

                entity.Property(e => e.cyber_complance).HasMaxLength(5000);

                entity.Property(e => e.edit_log).HasMaxLength(5000);

                entity.Property(e => e.minimum_software_requirements).HasMaxLength(5000);

                entity.Property(e => e.other_capabilities).HasMaxLength(5000);

                entity.Property(e => e.other_compatability).HasMaxLength(5000);

                entity.Property(e => e.price).HasMaxLength(5000);

                entity.Property(e => e.product_SKU).HasMaxLength(50);

                entity.Property(e => e.product_description).HasMaxLength(5000);

                entity.Property(e => e.product_logo).HasMaxLength(5000);

                entity.Property(e => e.product_name).HasMaxLength(50);

                entity.Property(e => e.product_version).HasMaxLength(500);

                entity.Property(e => e.ratings).HasMaxLength(5000);

                entity.Property(e => e.redemption_url).HasMaxLength(500);

                entity.Property(e => e.retention_rate).HasMaxLength(5000);

                entity.Property(e => e.review_url).HasMaxLength(500);

                entity.Property(e => e.sales_discount).HasMaxLength(5000);

                entity.Property(e => e.sme_support).HasMaxLength(5000);

                entity.Property(e => e.target_customer).HasMaxLength(5000);

                entity.Property(e => e.website_url).HasMaxLength(5000);

                entity.Property(e => e.draft_product_description).HasMaxLength(5000);

                entity.Property(e => e.draft_other_capabilities).HasMaxLength(5000);

                entity.Property(e => e.draft_other_compatability).HasMaxLength(5000);

                entity.Property(e => e.draft_review_url).HasMaxLength(500); 
            });

            modelBuilder.Entity<product_price>(entity =>
            {
                entity.HasKey(e => e.product_price_id);

                entity.ToTable("product_price");

                entity.HasIndex(e => e.free_trial_end_action_id, "IX_product_price_free_trial_end_action_id");

                entity.HasIndex(e => e.productid, "IX_product_price_productid");

                entity.Property(e => e.commitment_unit).HasMaxLength(200);

                entity.Property(e => e.contract_duration_discount_description).HasMaxLength(5000);

                entity.Property(e => e.contract_duration_discount_unit).HasMaxLength(200);

                entity.Property(e => e.discount_application_description).HasMaxLength(5000);

                entity.Property(e => e.discount_term_unit).HasMaxLength(200);

                entity.Property(e => e.free_trial_term_unit).HasMaxLength(200);

                entity.Property(e => e.min_users_flag).HasMaxLength(200);

                entity.Property(e => e.payment_terms_discount_description).HasMaxLength(5000);

                entity.Property(e => e.payment_terms_discount_unit).HasMaxLength(200);

                entity.Property(e => e.product_price_sku).HasMaxLength(200);

                entity.Property(e => e.product_price_title).HasMaxLength(200);

                entity.HasOne(d => d.free_trial_end_action)
                    .WithMany(p => p.product_prices)
                    .HasForeignKey(d => d.free_trial_end_action_id);

                entity.HasOne(d => d.product)
                    .WithMany(p => p.product_prices)
                    .HasForeignKey(d => d.productid)
                    .HasConstraintName("FK_product_price_products_product_id");
            });

            modelBuilder.Entity<product_price_base_description>(entity =>
            {
                entity.HasKey(e => e.product_price_base_description_id);

                entity.ToTable("product_price_base_description");

                entity.Property(e => e.product_price_basedescription).HasMaxLength(5000);
            });

            modelBuilder.Entity<product_price_base_metric_price>(entity =>
            {
                entity.HasKey(e => e.product_price_base_id);

                entity.ToTable("product_price_base_metric_price");

                entity.HasIndex(e => e.product_price_base_description_id,
                    "IX_product_price_base_metric_price_product_price_base_descript~");

                entity.HasIndex(e => e.product_price_id, "IX_product_price_base_metric_price_product_price_id");

                entity.HasOne(d => d.product_price_base_description)
                    .WithMany(p => p.product_price_base_metric_prices)
                    .HasForeignKey(d => d.product_price_base_description_id)
                    .HasConstraintName("FK_product_price_base_metric_price_product_price_base_descript~");

                entity.HasOne(d => d.product_price)
                    .WithMany(p => p.product_price_base_metric_prices)
                    .HasForeignKey(d => d.product_price_id)
                    .HasConstraintName("FK_product_price_base_metric_price_product_price_product_price~");
            });

            modelBuilder.Entity<product_price_secondary_description>(entity =>
            {
                entity.HasKey(e => e.product_price_sec_description_id);

                entity.ToTable("product_price_secondary_description");

                entity.Property(e => e.product_price_sec_description).HasMaxLength(5000);
            });

            modelBuilder.Entity<product_price_secondary_metric>(entity =>
            {
                entity.HasKey(e => e.product_price_sec_id);

                entity.ToTable("product_price_secondary_metric");

                entity.HasIndex(e => e.product_price_sec_description_id,
                    "IX_product_price_secondary_metric_product_price_sec_descripti~");

                entity.HasIndex(e => e.product_price_id, "IX_product_price_secondary_metric_product_price_id");

                entity.HasOne(d => d.product_price_secondary_description)
                    .WithMany(p => p.product_price_secondary_metrics)
                    .HasForeignKey(d => d.product_price_sec_description_id)
                    .HasConstraintName("FK_product_price_secondary_metric_product_price_sec_descripti~");

                entity.HasOne(d => d.product_price)
                    .WithMany(p => p.product_price_secondary_metrics)
                    .HasForeignKey(d => d.product_price_id)
                    .HasConstraintName("FK_product_price_secondary_metric_product_price_product_price_~");
            });

            modelBuilder.Entity<product_status>(entity =>
            {
                entity.ToTable("product_status");

                //Commented these as not there in prod. Can revert while doing next inflight migration
                //entity.HasData(
                //    new product_status
                //    {
                //        id = 1,
                //        status_description = "Incomplete"
                //    },
                //    new product_status
                //    {
                //        id = 10,
                //        status_description = "In review"
                //    },
                //    new product_status
                //    {
                //        id = 50,
                //        status_description = "Approved"
                //    },
                //    new product_status
                //    {
                //        id = 1000,
                //        status_description = "Not in scheme"
                //    });
            });

            modelBuilder.Entity<settings_category_type>(entity =>
            {
                entity.HasKey(e => e.category_type_id)
                    .HasName("pk_settings_category_type");

                entity.ToTable("settings_category_type");

                entity.HasIndex(e => e.product_type, "ixfk_settings_category_type_settings_product_types");

                entity.Property(e => e.category_name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasData(
                    new settings_category_type
                    {
                        category_type_id = 1,
                        product_type = 1,
                        category_name = "Financial Reporting and Analysis",
                        sort_order = 1
                    },
                    new settings_category_type
                    {
                        category_type_id = 2,
                        product_type = 1,
                        category_name = "Billing and Invoicing",
                        sort_order = 1
                    },
                    new settings_category_type
                    {
                        category_type_id = 3,
                        product_type = 1,
                        category_name = "Project Accounting",
                        sort_order = 1
                    },
                    new settings_category_type
                    {
                        category_type_id = 4,
                        product_type = 1,
                        category_name = "Revenue Management",
                        sort_order = 1
                    });
            });

            modelBuilder.Entity<settings_licence_type>(entity =>
            {
                entity.ToTable("settings_licence_type");

                entity.HasComment(
                    "The table has following record values  1- One-off 2- Subscription based 3- Pay-per-user-per-month 4- Others");

                entity.HasIndex(e => e.id, "ixfk_licence_type_product");

                entity.Property(e => e.id).ValueGeneratedNever();

                entity.Property(e => e.item_name).HasMaxLength(50);
            });

            modelBuilder.Entity<settings_product_capability>(entity =>
            {
                entity.HasKey(e => e.capability_id);

                entity.Property(e => e.capability_name).HasMaxLength(500);

                entity.HasData(
                    //Accountancy
                    new settings_product_capability
                    {
                        capability_id = 1, capability_name = "Financial Reporting and Analysis", product_type = 1,
                        sort_order = 1
                    },
                    new settings_product_capability
                    {
                        capability_id = 2, capability_name = "Billing and Invoicing", product_type = 1, sort_order = 1
                    },
                    new settings_product_capability
                        {capability_id = 3, capability_name = "Project Accounting", product_type = 1, sort_order = 1},
                    new settings_product_capability
                        {capability_id = 4, capability_name = "Revenue Management", product_type = 1, sort_order = 1},
                    new settings_product_capability
                        {capability_id = 5, capability_name = "Contract Accounting", product_type = 1, sort_order = 1},
                    new settings_product_capability
                        {capability_id = 6, capability_name = "Revenue Recognition", product_type = 1, sort_order = 1},
                    new settings_product_capability
                        {capability_id = 7, capability_name = "Supplier Management", product_type = 1, sort_order = 1},
                    new settings_product_capability
                    {
                        capability_id = 8, capability_name = "Work Breakdown Structure (WBS) Management",
                        product_type = 1, sort_order = 1
                    },
                    new settings_product_capability
                    {
                        capability_id = 9, capability_name = "Purchase Request Management", product_type = 1,
                        sort_order = 1
                    },
                    new settings_product_capability
                    {
                        capability_id = 10, capability_name = "Purchase Order Management", product_type = 1,
                        sort_order = 1
                    },
                    new settings_product_capability
                        {capability_id = 11, capability_name = "Asset Management", product_type = 1, sort_order = 1},
                    new settings_product_capability
                        {capability_id = 12, capability_name = "Debt Management", product_type = 1, sort_order = 1},
                    new settings_product_capability
                        {capability_id = 13, capability_name = "Interest Management", product_type = 1, sort_order = 1},
                    new settings_product_capability
                    {
                        capability_id = 14, capability_name = "Cash Position Management", product_type = 1,
                        sort_order = 1
                    },
                    new settings_product_capability
                    {
                        capability_id = 15, capability_name = "Financial Risk Management", product_type = 1,
                        sort_order = 1
                    },
                    new settings_product_capability
                        {capability_id = 16, capability_name = "Currency Management", product_type = 1, sort_order = 1},
                    new settings_product_capability
                        {capability_id = 17, capability_name = "Expense Management", product_type = 1, sort_order = 1},
                    new settings_product_capability
                    {
                        capability_id = 18, capability_name = "Purchase Order (PO) Workflow & Approvals",
                        product_type = 1, sort_order = 1
                    },
                    new settings_product_capability
                        {capability_id = 19, capability_name = "Payment Management", product_type = 1, sort_order = 1},
                    new settings_product_capability
                    {
                        capability_id = 20,
                        capability_name =
                            "Earnings Before Interest, Taxes, Depreciation & Amortization (EBITDA) Calculation",
                        product_type = 1, sort_order = 1
                    },
                    //E-commerce
                    new settings_product_capability
                    {
                        capability_id = 21, capability_name = "Pricing Rule Management", product_type = 3,
                        sort_order = 2
                    },
                    new settings_product_capability
                        {capability_id = 22, capability_name = "Discount Management", product_type = 3, sort_order = 2},
                    new settings_product_capability
                        {capability_id = 23, capability_name = "Coupon Management", product_type = 3, sort_order = 2},
                    new settings_product_capability
                        {capability_id = 24, capability_name = "Order Orchestration", product_type = 3, sort_order = 2},
                    new settings_product_capability
                    {
                        capability_id = 25, capability_name = "Inventory Management", product_type = 3, sort_order = 2
                    },
                    new settings_product_capability
                    {
                        capability_id = 26, capability_name = "Supply Chain & Distribution Integration",
                        product_type = 3, sort_order = 2
                    },
                    new settings_product_capability
                        {capability_id = 27, capability_name = "Commerce Analytics", product_type = 3, sort_order = 2},
                    new settings_product_capability
                        {capability_id = 28, capability_name = "Product Analytics", product_type = 3, sort_order = 2},
                    new settings_product_capability
                        {capability_id = 29, capability_name = "Personalisation", product_type = 3, sort_order = 2},
                    new settings_product_capability
                        {capability_id = 30, capability_name = "Digital Marketing", product_type = 3, sort_order = 2},
                    new settings_product_capability
                        {capability_id = 31, capability_name = "Loyalty Management", product_type = 3, sort_order = 2},
                    new settings_product_capability
                        {capability_id = 32, capability_name = "Currency Management", product_type = 3, sort_order = 2},
                    new settings_product_capability
                    {
                        capability_id = 33, capability_name = "Service Activation & Provisioning", product_type = 3,
                        sort_order = 2
                    },
                    new settings_product_capability
                        {capability_id = 34, capability_name = "Product Search", product_type = 3, sort_order = 2},
                    new settings_product_capability
                        {capability_id = 35, capability_name = "Product Comparison", product_type = 3, sort_order = 2},
                    new settings_product_capability
                    {
                        capability_id = 36, capability_name = "Product Recommendation", product_type = 3, sort_order = 2
                    },
                    new settings_product_capability
                    {
                        capability_id = 37, capability_name = "Order History Management", product_type = 3,
                        sort_order = 2
                    },
                    new settings_product_capability
                    {
                        capability_id = 38, capability_name = "Return Materials Authorisation (RMA) Management",
                        product_type = 3, sort_order = 2
                    },
                    new settings_product_capability
                    {
                        capability_id = 39, capability_name = "Customer Review Management", product_type = 3,
                        sort_order = 2
                    },
                    new settings_product_capability
                    {
                        capability_id = 40, capability_name = "Customer Service Integration", product_type = 3,
                        sort_order = 2
                    },
                    new settings_product_capability
                    {
                        capability_id = 41, capability_name = "Warranty & Entitlement Management", product_type = 3,
                        sort_order = 2
                    },
                    new settings_product_capability
                    {
                        capability_id = 42, capability_name = "Translation and Region Variants", product_type = 3,
                        sort_order = 2
                    },
                    new settings_product_capability
                    {
                        capability_id = 43, capability_name = "Transactional Configure, Price, Quote (CPQ)",
                        product_type = 3, sort_order = 2
                    },
                    //CRM
                    new settings_product_capability
                        {capability_id = 44, capability_name = "Offer Management", product_type = 2, sort_order = 3},
                    new settings_product_capability
                        {capability_id = 45, capability_name = "Order Management", product_type = 2, sort_order = 3},
                    new settings_product_capability
                        {capability_id = 46, capability_name = "Contract Management", product_type = 2, sort_order = 3},
                    new settings_product_capability
                        {capability_id = 47, capability_name = "Document Templates", product_type = 2, sort_order = 3},
                    new settings_product_capability
                        {capability_id = 48, capability_name = "Document Management", product_type = 2, sort_order = 3},
                    new settings_product_capability
                    {
                        capability_id = 49, capability_name = "Correspondence Management", product_type = 2,
                        sort_order = 3
                    },
                    new settings_product_capability
                        {capability_id = 50, capability_name = "Quote Management", product_type = 2, sort_order = 3},
                    new settings_product_capability
                    {
                        capability_id = 51, capability_name = "Territory Management", product_type = 2, sort_order = 3
                    },
                    new settings_product_capability
                        {capability_id = 52, capability_name = "Invoice Management", product_type = 2, sort_order = 3},
                    new settings_product_capability
                        {capability_id = 53, capability_name = "Event Management", product_type = 2, sort_order = 3},
                    new settings_product_capability
                        {capability_id = 54, capability_name = "Comms Preferences", product_type = 2, sort_order = 3},
                    new settings_product_capability
                        {capability_id = 55, capability_name = "Brand Management", product_type = 2, sort_order = 3},
                    new settings_product_capability
                    {
                        capability_id = 56, capability_name = "Assignment Management", product_type = 2, sort_order = 3
                    },
                    new settings_product_capability
                        {capability_id = 57, capability_name = "Skills Management", product_type = 2, sort_order = 3},
                    new settings_product_capability
                    {
                        capability_id = 58, capability_name = "Configure, Price, Quote (CPQ)", product_type = 2,
                        sort_order = 3
                    },
                    new settings_product_capability
                    {
                        capability_id = 59, capability_name = "Service Level Agreement (SLA) Management",
                        product_type = 2, sort_order = 3
                    },
                    new settings_product_capability
                        {capability_id = 60, capability_name = "Asset Management", product_type = 2, sort_order = 3},
                    new settings_product_capability
                    {
                        capability_id = 61, capability_name = "Install Base Management", product_type = 2,
                        sort_order = 3
                    },
                    new settings_product_capability
                    {
                        capability_id = 62, capability_name = "Customer Portal & Self-Service", product_type = 2,
                        sort_order = 3
                    },
                    //new settings_product_capability { capability_id = 63, capability_name = "Document Templates", product_type = 2, sort_order = 3 },
                    //new settings_product_capability { capability_id = 64, capability_name = "Correspondence Management", product_type = 2, sort_order = 3 },
                    new settings_product_capability
                    {
                        capability_id = 65, capability_name = "Workflow Management & Process Automation",
                        product_type = 2, sort_order = 3
                    },
                    new settings_product_capability
                        {capability_id = 66, capability_name = "Product Management", product_type = 2, sort_order = 3},
                    new settings_product_capability
                    {
                        capability_id = 67, capability_name = "Notification and Alert Management", product_type = 2,
                        sort_order = 3
                    },
                    new settings_product_capability
                    {
                        capability_id = 68, capability_name = "Workforce Management", product_type = 2, sort_order = 3
                    },
                    new settings_product_capability
                        {capability_id = 69, capability_name = "Service Analysis", product_type = 2, sort_order = 3},
                    new settings_product_capability
                    {
                        capability_id = 70, capability_name = "Communications Management", product_type = 2,
                        sort_order = 3
                    },
                    new settings_product_capability
                    {
                        capability_id = 71, capability_name = "Multi-Variant Testing", product_type = 2, sort_order = 3
                    },
                    new settings_product_capability
                    {
                        capability_id = 72, capability_name = "Digital Marketing Management", product_type = 2,
                        sort_order = 3
                    },
                    new settings_product_capability
                        {capability_id = 73, capability_name = "Personalisation", product_type = 2, sort_order = 3},
                    new settings_product_capability
                        {capability_id = 74, capability_name = "Loyalty Management", product_type = 2, sort_order = 3},
                    new settings_product_capability
                    {
                        capability_id = 75, capability_name = "Next Best Action (X-Sell / Upsell)", product_type = 2,
                        sort_order = 3
                    },
                    new settings_product_capability
                        {capability_id = 76, capability_name = "Survey Management", product_type = 2, sort_order = 3}
                );
            });

            modelBuilder.Entity<settings_product_filter>(entity =>
            {
                entity.HasKey(e => e.filter_id);

                entity.Property(e => e.filter_name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasData(
                    new settings_product_filter
                    {
                        filter_id = 1,
                        filter_type = 1,
                        filter_name = "Email",
                        sort_order = 10
                    },
                    new settings_product_filter
                    {
                        filter_id = 2,
                        filter_type = 1,
                        filter_name = "Phone support",
                        sort_order = 20
                    },
                    new settings_product_filter
                    {
                        filter_id = 3,
                        filter_type = 1,
                        filter_name = "Chat",
                        sort_order = 30
                    },
                    new settings_product_filter
                    {
                        filter_id = 4,
                        filter_type = 1,
                        filter_name = "Web form",
                        sort_order = 40
                    },
                    new settings_product_filter
                    {
                        filter_id = 5,
                        filter_type = 1,
                        filter_name = "Social media",
                        sort_order = 50
                    },
                    new settings_product_filter
                    {
                        filter_id = 6,
                        filter_type = 1,
                        filter_name = "Forum",
                        sort_order = 60
                    },
                    new settings_product_filter
                    {
                        filter_id = 7,
                        filter_type = 1,
                        filter_name = "FAQs",
                        sort_order = 70
                    },
                    new settings_product_filter
                    {
                        filter_id = 8,
                        filter_type = 1,
                        filter_name = "Knowledge base",
                        sort_order = 80
                    },
                    new settings_product_filter
                    {
                        filter_id = 9,
                        filter_type = 2,
                        filter_name = "In-person",
                        sort_order = 10
                    },
                    new settings_product_filter
                    {
                        filter_id = 10,
                        filter_type = 2,
                        filter_name = "Live online",
                        sort_order = 20
                    },
                    new settings_product_filter
                    {
                        filter_id = 11,
                        filter_type = 2,
                        filter_name = "Webinars",
                        sort_order = 30
                    },
                    new settings_product_filter
                    {
                        filter_id = 12,
                        filter_type = 2,
                        filter_name = "Documentation",
                        sort_order = 40
                    },
                    new settings_product_filter
                    {
                        filter_id = 13,
                        filter_type = 2,
                        filter_name = "Videos",
                        sort_order = 50
                    },
                    new settings_product_filter
                    {
                        filter_id = 14,
                        filter_type = 3,
                        filter_name = "Vendor Cloud/SaaS - multi-tenant (public)",
                        sort_order = 10
                    },
                    new settings_product_filter
                    {
                        filter_id = 15,
                        filter_type = 3,
                        filter_name = "Vendor Cloud/SaaS - single-tenant (private)",
                        sort_order = 20
                    },
                    new settings_product_filter
                    {
                        filter_id = 16,
                        filter_type = 3,
                        filter_name = "Supported browser - Edge",
                        sort_order = 30
                    },
                    new settings_product_filter
                    {
                        filter_id = 17,
                        filter_type = 3,
                        filter_name = "Supported browser - Chrome",
                        sort_order = 40
                    },
                    new settings_product_filter
                    {
                        filter_id = 18,
                        filter_type = 3,
                        filter_name = "Supported browser - Safari",
                        sort_order = 50
                    },
                    new settings_product_filter
                    {
                        filter_id = 19,
                        filter_type = 3,
                        filter_name = "Supported browser - Firefox",
                        sort_order = 60
                    },
                    new settings_product_filter
                    {
                        filter_id = 20,
                        filter_type = 3,
                        filter_name = "Desktop deployment - Windows",
                        sort_order = 70
                    },
                    new settings_product_filter
                    {
                        filter_id = 21,
                        filter_type = 3,
                        filter_name = "Desktop deployment - Mac",
                        sort_order = 80
                    },
                    new settings_product_filter
                    {
                        filter_id = 22,
                        filter_type = 3,
                        filter_name = "Desktop deployment - Virtual Desktop support",
                        sort_order = 90
                    },
                    new settings_product_filter
                    {
                        filter_id = 23,
                        filter_type = 3,
                        filter_name = "Server-based / private cloud - Windows",
                        sort_order = 100
                    },
                    new settings_product_filter
                    {
                        filter_id = 24,
                        filter_type = 3,
                        filter_name = "Server-based / private cloud - Linux",
                        sort_order = 110
                    },
                    new settings_product_filter
                    {
                        filter_id = 25,
                        filter_type = 3,
                        filter_name = "Server-based / private cloud - Unix",
                        sort_order = 120
                    },
                    new settings_product_filter
                    {
                        filter_id = 26,
                        filter_type = 3,
                        filter_name = "Mobile - Android",
                        sort_order = 130
                    },
                    new settings_product_filter
                    {
                        filter_id = 27,
                        filter_type = 3,
                        filter_name = "Mobile - iOS-iPhone",
                        sort_order = 140
                    });
            });

            modelBuilder.Entity<settings_product_filters_category>(entity =>
            {
                entity.Property(e => e.item_name).HasMaxLength(50);

                entity.HasData(
                    new settings_product_filters_category
                    {
                        id = 1,
                        item_name = "Support"
                    },
                    new settings_product_filters_category
                    {
                        id = 2,
                        item_name = "Training"
                    },
                    new settings_product_filters_category
                    {
                        id = 3,
                        item_name = "Platform"
                    });
            });

            modelBuilder.Entity<settings_product_type>(entity =>
            {
                //entity.HasNoKey();

                entity.HasComment("The table has three record values  1- Accountancy 2- E-commerce 3- CRM");

                entity.Property(e => e.item_name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasData(
                    new settings_product_type
                    {
                        id = 1,
                        item_name = "Accountancy"
                    },
                    new settings_product_type
                    {
                        id = 2,
                        item_name = "CRM"
                    },
                    new settings_product_type
                    {
                        id = 3,
                        item_name = "E-commerce"
                    });
            });

            modelBuilder.Entity<settings_project>(entity =>
            {
                entity.HasKey(e => e.settings_key)
                    .HasName("pk_project_settings");

                entity.ToTable("settings_project");

                entity.Property(e => e.settings_key).HasMaxLength(50);

                entity.Property(e => e.settings_value).HasMaxLength(500);

                entity.HasData(
                    new settings_project
                    {
                        settings_key = "MAX_PRODUCT_BY_CATEGORY",
                        settings_value = "3"
                    },
                    new settings_project
                    {
                        settings_key = "MAX_PRODUCT_LIVE",
                        settings_value = "9"
                    });
     
            });

            modelBuilder.Entity<token>(entity =>
            {
                entity.HasKey(e => e.token_id);
                         
                entity.HasOne<token_cancellation_status>(x => x.token_Cancellation_Status)
                .WithMany()
                .HasForeignKey(x => x.cancellation_status_id);

                entity.ToTable("token");
            });

            modelBuilder.Entity<token_reconciliation_status>(entity =>
            {
                entity.HasKey(e => e.reconciliation_status_id);

                entity.ToTable("token_reconciliation_status");

                entity.Property(e => e.reconciliation_status_desc).IsRequired();

                entity.HasData(
                    new token_reconciliation_status 
                    {
                        reconciliation_status_id = 1,
                        reconciliation_status_desc = "Pending reconciliation"
                    },
                    new token_reconciliation_status
                    {
                        reconciliation_status_id = 2,
                        reconciliation_status_desc = "Reconciliation completed"
                    });
            });

            modelBuilder.Entity<token_redemption_status>(entity =>
            {
                entity.HasKey(e => e.redemption_status_id);

                entity.ToTable("token_redemption_status");

                entity.Property(e => e.redemption_status_desc).IsRequired();

                entity.HasData(
                    new token_redemption_status
                    {
                        redemption_status_id = 1,
                        redemption_status_desc = "Pending redemption"
                    },
                    new token_redemption_status
                    {
                        redemption_status_id = 2,
                        redemption_status_desc = "Pending completed"
                    });
            });

            modelBuilder.Entity<user_discount>(entity =>
            {
                entity.HasKey(e => e.user_discount_id);

                entity.ToTable("user_discount");

                entity.HasIndex(e => e.product_price_id, "IX_user_discount_product_price_id");

                entity.Property(e => e.discount_sku).HasMaxLength(200);

                entity.HasOne(d => d.product_price)
                    .WithMany(p => p.user_discounts)
                    .HasForeignKey(d => d.product_price_id);
            });

            modelBuilder.Entity<vendor_api_call_status>(entity =>
            {
                entity.HasKey(e => e.call_id);

                entity.ToTable("vendor_api_call_status");

                entity.Property(e => e.vendor_id).IsRequired();
            });

            modelBuilder.Entity<vendor_reconciliation>(entity =>
            {
                entity.HasKey(e => e.reconciliation_id);

                entity.ToTable("vendor_reconciliation");

                entity.HasOne(d => d.reconciliation)
                    .WithOne(p => p.vendor_reconciliation)
                    .HasForeignKey<vendor_reconciliation>(d => d.reconciliation_id)
                    .HasConstraintName("FK_vendor_reconciliation_vendor_reconciliation_sales_reconcili~");
            });

            modelBuilder.Entity<vendor_company>(entity =>
            {
                entity.HasKey(e => e.vendorid)
                    .HasName("pk_vendor");

                entity.ToTable("vendor_company");

                entity.Property(e => e.access_secret).HasMaxLength(50);

                entity.Property(e => e.access_secret_code).HasMaxLength(1);

                entity.Property(e => e.application_status).HasComment("status of application, 10,20,30,40,50 see HLD");

                entity.Property(e => e.edit_log).HasMaxLength(1);

                entity.Property(e => e.encryption_code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment(
                        "16 digit encryption salt to be generate during the record creation. This is a unique record");

                entity.Property(e => e.ip_access_end).HasMaxLength(30);

                entity.Property(e => e.ip_access_start).HasMaxLength(30);

                entity.Property(e => e.ipaddresses).HasMaxLength(500);

                entity.Property(e => e.locked_by).HasComment(
                    "The admin id who has locked the item for review. once locked >0 , it will appear in the management console queue but cannot be opened by another admin. The status will be displayed accordingly");

                entity.Property(e => e.registration_id)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("This is id that will be used by the Vendor to speak to the VOS team");

                entity.Property(e => e.vendor_company_address_1)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasComment("company house ID");

                entity.Property(e => e.vendor_company_address_2).HasMaxLength(500);

                entity.Property(e => e.vendor_company_city)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.vendor_company_house_reg_no)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.vendor_company_name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.vendor_company_postcode)
                    .IsRequired()
                    .HasMaxLength(8);

                entity.Property(e => e.vendor_company_profile).HasMaxLength(5000);

                entity.Property(e => e.vendor_notification_email).HasMaxLength(50);

                entity.Property(e => e.vendor_notification_phone).HasMaxLength(50);

                entity.Property(e => e.vendor_website_url).HasMaxLength(50);
            });

            modelBuilder.Entity<vendor_company_user>(entity =>
            {
                entity.HasKey(e => e.userid)
                    .HasName("pk_vendor_company_user");

                entity.ToTable("vendor_company_user");

                entity.HasIndex(e => e.companyid, "ixfk_vendor_company_user_vendor_company");

                entity.HasIndex(e => e.companyid, "ixfk_vendor_company_user_vendor_company_02");

                entity.Property(e => e.access_link).HasMaxLength(500);

                entity.Property(e => e.adb2c).HasColumnType("character varying");

                entity.Property(e => e.contact)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.email)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.full_name)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.permission_level).HasDefaultValueSql("0");

                entity.Property(e => e.position)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.company)
                    .WithMany(p => p.vendor_company_users)
                    .HasForeignKey(d => d.companyid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_vendor_company_user_vendor_company_02");
            });

            modelBuilder.Entity<vendor_reconciliation_sale>(entity =>
            {
                entity.HasKey(e => e.reconciliation_sales_id);
            });

            modelBuilder.Entity<vendor_status>(entity =>
            {
                entity.ToTable("vendor_status");
            });

            modelBuilder.Entity<companies_house_api_result>(entity =>
            {
                entity.ToTable("companies_house_api_result");

                entity.HasKey(e => e.companies_house_api_result_id)
                   .HasName("pk_companies_house_api_result_id");

                entity.HasOne(a => a.registered_office_address)
                    .WithOne(b => b.companies_house_api_result)
                    .HasForeignKey<companies_house_registered_office_address>(b => b.companies_house_registered_office_address_id)
                    .HasConstraintName("FK_companies_house_api_result_companies_house_registered_office_address");
            });       

            modelBuilder.Entity<companies_house_registered_office_address>(entity =>
            {
                entity.ToTable("companies_house_registered_office_address");

                entity.HasKey(e => e.companies_house_registered_office_address_id)
                   .HasName("pk_companies_house_registered_office_address_id");
            });
            
            modelBuilder.Entity<token_cancellation_status>(entity =>
            {
                entity.ToTable("token_cancellation_status");
                entity.HasKey(e => e.cancellation_status_id)
                .HasName("token_cancellation_status_pkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}