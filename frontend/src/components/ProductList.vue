<template>
  <div class="product-page">
    <!-- Header -->
    <header class="header">
      <h2>🛒 Store</h2>
    </header>

    <!-- Filters -->
    <div class="filters">
      <input v-model="filters.search" placeholder="Search by name" />
      <select v-model="filters.category">
        <option value="">All Categories</option>
        <option v-for="cat in categories" :key="cat">{{ cat }}</option>
      </select>
      <input v-model.number="filters.minPrice" type="number" placeholder="Min Price" />
      <input v-model.number="filters.maxPrice" type="number" placeholder="Max Price" />
      <button @click="resetFilters">Reset</button>
    </div>

    <!-- Loading -->
    <div v-if="loading" class="loading">Loading products...</div>

    <!-- Product Grid -->
    <div class="product-grid">
      <div v-for="product in products" :key="product.id" class="product-card">
        <img :src="product.imageUrl" :alt="product.name" />
        <h3>{{ product.name }}</h3>
        <p>{{ product.category }}</p>
        <p class="price">₹{{ product.price }}</p>
      </div>
    </div>

    <!-- Pagination -->
    <div class="pagination">
      <button @click="prevPage" :disabled="page <= 1">Previous</button>

      <button
        v-for="p in totalPages"
        :key="p"
        :class="{ active: page === p }"
        @click="page = p"
      >
        {{ p }}
      </button>

      <button @click="nextPage" :disabled="page >= totalPages">Next</button>

      <select v-model.number="pageSize">
        <option :value="6">6</option>
        <option :value="12">12</option>
      </select>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import debounce from "lodash/debounce";

export default {
  data() {
    return {
      products: [],
      total: 0,
      page: 1,
      pageSize: 6,
      loading: false,
      filters: {
        search: "",
        category: "",
        minPrice: null,
        maxPrice: null,
      },
      categories: [
        "Electronics",
        "Clothing",
        "Footwear",
        "Stationery",
        "Home Decor",
        "Accessories",
        "Furniture",
      ],
    };
  },
  created() {
    this.debouncedFetchProducts = debounce(this.fetchProducts, 400);
    this.debouncedFetchProducts();
  },
  watch: {
    page() {
      this.debouncedFetchProducts();
    },
    pageSize() {
      this.page = 1;
      this.debouncedFetchProducts();
    },
    "filters.search"() {
      this.page = 1;
      this.debouncedFetchProducts();
    },
    "filters.category"() {
      this.page = 1;
      this.debouncedFetchProducts();
    },
    "filters.minPrice"() {
      this.page = 1;
      this.debouncedFetchProducts();
    },
    "filters.maxPrice"() {
      this.page = 1;
      this.debouncedFetchProducts();
    },
  },
  computed: {
    totalPages() {
      return Math.ceil(this.total / this.pageSize);
    },
  },
  methods: {
    fetchProducts() {
      this.loading = true;

      const params = {
        page: this.page,
        pageSize: this.pageSize,
      };

      if (this.filters.search) params.search = this.filters.search;
      if (this.filters.category) params.category = this.filters.category;
      if (this.filters.minPrice !== null) params.minPrice = this.filters.minPrice;
      if (this.filters.maxPrice !== null) params.maxPrice = this.filters.maxPrice;

      axios
        .get("/api/products", { params })
        .then((res) => {
          this.products = res.data.products;
          this.total = res.data.total;
        })
        .catch((err) => {
          console.error("API error:", err);
          this.products = [];
          this.total = 0;
        })
        .finally(() => {
          this.loading = false;
        });
    },
    resetFilters() {
      this.filters = {
        search: "",
        category: "",
        minPrice: null,
        maxPrice: null,
      };
      this.page = 1;
      this.debouncedFetchProducts();
    },
    nextPage() {
      if (this.page < this.totalPages) this.page++;
    },
    prevPage() {
      if (this.page > 1) this.page--;
    },
  },
};
</script>

<style scoped>
.product-page {
  padding: 20px;
  font-family: Arial, sans-serif;
}

.header {
  background: linear-gradient(to right, #4CAF50, #2196F3);
  color: white;
  padding: 16px;
  margin-bottom: 20px;
  text-align: center;
  border-radius: 8px;
}

.filters {
  display: flex;
  flex-wrap: wrap;
  gap: 10px;
  margin-bottom: 20px;
  justify-content: center;
}

input,
select,
button {
  padding: 8px;
  border-radius: 4px;
  border: 1px solid #ccc;
}

.loading {
  text-align: center;
  margin: 20px 0;
  font-weight: bold;
}

.product-grid {
  display: grid;
  grid-template-columns: repeat(auto-fit, minmax(200px, 1fr));
  gap: 16px;
  margin-bottom: 20px;
}

.product-card {
  border: 1px solid #ddd;
  padding: 12px;
  border-radius: 8px;
  text-align: center;
  background: #fff;
  box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
}

.product-card img {
  max-width: 100%;
  height: 150px;
  object-fit: cover;
  margin-bottom: 8px;
}

.price {
  color: green;
  font-weight: bold;
  margin-top: 4px;
}

.pagination {
  text-align: center;
  margin-top: 20px;
}

.pagination button {
  margin: 2px;
  padding: 6px 12px;
  border-radius: 4px;
}

.pagination button.active {
  background-color: #4CAF50;
  color: white;
}
</style>
