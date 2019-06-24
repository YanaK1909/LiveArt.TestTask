<template>
  <div class="card mb-4 shadow-sm product-item">
    <div class="image-container">
      <img :src="product.thumbnailImage" :alt="product.name"/>
    </div>
    <div class="card-body">
      <h4>{{product.name}}</h4>
      <p>{{product.description}}</p>
      <div class="d-flex justify-content-between align-items-center">
        <div class="btn-group">
          <router-link :to="'/product/' + product.id">
            <button type="button" class="btn btn-sm btn-outline-secondary">View</button>
          </router-link>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'ProductItem',
  props: ['product']
}
</script>
