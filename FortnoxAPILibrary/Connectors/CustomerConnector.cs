﻿namespace FortnoxAPILibrary.Connectors
{
    /// <inheritdoc />
    public interface ICustomerConnector : IEntityConnector<Sort.By.Customer>
    {
        /// <remarks/>
        Filter.Customer FilterBy { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string City { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string CustomerNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string Email { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string OrganisationNumber { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string Phone { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string ZipCode { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string GLN { get; set; }

        /// <summary>
        /// Use with Find() to limit the search result
        /// </summary>
        string GLNDelivery { get; set; }

        /// <summary>
        /// Find a customer based on customernumber
        /// </summary>
        /// <param name="customerNumber">The customernumber to find</param>
        /// <returns>The found customer</returns>
        Customer Get(string customerNumber);

        /// <summary>
        /// Updates a customer
        /// </summary>
        /// <param name="customer">The customer to update</param>
        /// <returns>The updated customer</returns>
        Customer Update(Customer customer);

        /// <summary>
        /// Create a new customer
        /// </summary>
        /// <param name="customer">The customer to create</param>
        /// <returns>The created customer</returns>
        Customer Create(Customer customer);

        /// <summary>
        /// Deletes a customer
        /// </summary>
        /// <param name="customerNumber">The customernumber to delete</param>
        void Delete(string customerNumber);

        /// <summary>
        /// Gets a list of customers
        /// </summary>
        /// <returns>A list of customers</returns>
        Customers Find();
    }

    /// <remarks/>
	public class CustomerConnector : EntityConnector<Customer, Customers, Sort.By.Customer>, ICustomerConnector
    {
		/// <remarks/>
		public enum Type
		{
			/// <remarks/>
			PRIVATE,
			/// <remarks/>
			COMPANY,
            /// <summary>
		    /// This is NOT a valid input for customer type, never set a customer type to this value. This only occurs in some cases when fetching from Fortnox.
		    /// When a customer in Fortnox has this state, it is not possible to update that customer, the request will fail with error 2001200 (Ogiltig kundtyp/Invalid customer type)
            /// </summary>
            UNDEFINED
        }

		/// <remarks/>
		public enum VATType
		{
			/// <remarks/>
			SEVAT,
			/// <remarks/>
			SEREVERSEDVAT,
			/// <remarks/>
			EUREVERSEDVAT,
			/// <remarks/>
			EUVAT,
			/// <remarks/>
			EXPORT
		}

		/// <remarks/>
		public enum DefaultInvoiceDeliveryType
		{
			/// <remarks/>
			EMAIL,
			/// <remarks/>
			PRINT,
			/// <remarks/>
			PRINTSERVICE,
            /// <remarks/>
            ELECTRONICINVOICE
		}

		/// <remarks/>
		public enum DefaultOfferDeliveryType
		{
			/// <remarks/>
			EMAIL,
			/// <remarks/>
			PRINT
		}

		/// <remarks/>
		public enum DefaultOrderDeliveryType
		{
			/// <remarks/>
			EMAIL,
			/// <remarks/>
			PRINT
		}

		private bool filterBySet = false;
		private Filter.Customer filterBy;
		/// <remarks/>
		[FilterProperty("filter")]
		public Filter.Customer FilterBy
		{
			get { return filterBy; }
			set
			{
				filterBy = value;
				filterBySet = true;
			}
		}


		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		[FilterProperty]
		public string City { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
		public string CustomerNumber { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
		public string Email { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
		public string Name { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
		public string OrganisationNumber { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
		public string Phone { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
        /// </summary>
        [FilterProperty]
		public string ZipCode { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		[FilterProperty]
		public string GLN { get; set; }

		/// <summary>
		/// Use with Find() to limit the search result
		/// </summary>
		[FilterProperty]
		public string GLNDelivery { get; set; }

		/// <remarks/>
		public CustomerConnector()
		{
			base.Resource = "customers";
		}


		/// <summary>
		/// Find a customer based on customernumber
		/// </summary>
		/// <param name="customerNumber">The customernumber to find</param>
		/// <returns>The found customer</returns>
		public Customer Get(string customerNumber)
		{
			return base.BaseGet(customerNumber);
		}

		/// <summary>
		/// Updates a customer
		/// </summary>
		/// <param name="customer">The customer to update</param>
		/// <returns>The updated customer</returns>
		public Customer Update(Customer customer)
		{
			return base.BaseUpdate(customer, customer.CustomerNumber);
		}

		/// <summary>
		/// Create a new customer
		/// </summary>
		/// <param name="customer">The customer to create</param>
		/// <returns>The created customer</returns>
		public Customer Create(Customer customer)
		{
			return base.BaseCreate(customer);
		}

		/// <summary>
		/// Deletes a customer
		/// </summary>
		/// <param name="customerNumber">The customernumber to delete</param>
		public void Delete(string customerNumber)
		{
			base.BaseDelete(customerNumber);
		}

		/// <summary>
		/// Gets a list of customers
		/// </summary>
		/// <returns>A list of customers</returns>
		public Customers Find()
		{
			return base.BaseFind();
		}
	}
}