import Vue from 'vue'
import Router from 'vue-router'
import ProductsListContainer from '@/components/productsList/ProductsListContainer'
import ProductDetailsContainer from '@/components/productDetails/ProductDetailsContainer'
import ProductEditContainer from '@/components/manage/product/ProductEditContainer'
import ProductsManageContainer from '@/components/manage/productsList/ProductsManageContainer'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      redirect: '/products'
    }, {
      path: '/products',
      name: 'ProductsListContainer',
      component: ProductsListContainer
    }, {
      path: '/product/:id',
      name: 'ProductDetailsContainer',
      component: ProductDetailsContainer
    }, {
      path: '/manage/products',
      name: 'ProductsManageContainer',
      component: ProductsManageContainer
    }, {
      path: '/manage/product/:id?',
      name: 'ProductEditContainer',
      component: ProductEditContainer
    }
  ]
})
