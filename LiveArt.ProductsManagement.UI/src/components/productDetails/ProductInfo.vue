<template>
  <div class="row product-details">
    <div class="col-md-5">
      <img :src="product.thumbnailImage" :alt="product.name"/>
    </div>
    <div class="col-md-7">
      <h1 class="jumbotron-heading">{{product.name}}</h1>
      <p class="lead text-muted">{{product.description}}</p>
    </div>
  </div>
</template>

<script>
export default {
  name: 'ProductInfo',
  props: ['product']
}
</script>
