<template>
  <div id="app">
    <header>
      <div class="navbar navbar-dark bg-dark shadow-sm">
        <div class="container">
          <router-link to="/products" class="navbar-brand d-flex align-items-center">
            <strong>Products</strong>
          </router-link>

          <router-link to="/manage/products" class="btn btn-light d-flex align-items-center">
            Administration
          </router-link>
        </div>
      </div>
    </header>

    <main role="main">
      <div class="container">
        <router-view/>
      </div>
    </main>
  </div>
</template>

<script>
export default {
  name: 'App'
}
</script>

<style>
#app {
}

#app .page-title {
  text-align: center;
}

.product-item .image-container {
  height: 225px;
  vertical-align: middle;
  overflow: hidden;
}

.product-item .image-container img{
  max-width: 100%;
}

.product-details {
  padding: 4rem 0;
}

.product-details img {
  max-width: 100%;
}

#app .jumbotron {
    background-color: #fff;
}

.back-container {
  padding: 2rem 15px 0;
}

.products-manage-toolbar {
  padding: 2rem 0;
}

.card-body p {
  height: 72px;
  overflow: hidden;
}

</style>
