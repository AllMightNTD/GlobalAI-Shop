<template>
  <div class="lg:px-[45px] mx-auto">
    <!-- Container -->
    <div class="min-h-[100vh] w-full">
      <!-- header -->
      <div class="pt-[20px] bg-white">
        <!-- navbar-one -->
        <div class="flex px-[20px] items-center justify-between">
          <h1 class="text-[24px] text-[#384059] w-[15%] font-semibold">
            Đơn Hàng
          </h1>
          <div
            class="px-[20px] py-[10px] flex-1 rounded-md bg-slate-100 flex justify-between"
          >
            <div class="flex items-center gap-[10px]">
              <h4 class="text-[#384059] text-[16px] font-[600]">
                Tổng số đơn hàng
              </h4>
              <span class="text-[#CC3366] text-[16px] font-medium">0</span>
            </div>
            <div class="flex items-center gap-[10px]">
              <h4 class="text-[#384059] text-[16px] font-[600]">
                Tổng giá trị đơn đã giao
              </h4>
              <span class="text-[#CC3366] text-[16px] font-medium">0 đ</span>
            </div>
            <div class="flex items-center gap-[10px]">
              <h4 class="text-[#384059] text-[16px] font-[600]">
                Hoa hồng đơn chờ đối soát
              </h4>
              <span class="text-[#CC3366] text-[16px] font-medium">0đ</span>
            </div>
            <div class="flex items-center gap-[10px]">
              <h4 class="text-[#384059] text-[16px] font-[600]">
                Tổng thu nhập đơn đã giao
              </h4>
              <span class="text-[#CC3366] text-[16px] font-medium">0đ</span>
            </div>
          </div>
        </div>
        <!-- navbar-two -->
        <div class="mt-[20px] border-b-[1px] border-slate-100">
          <div class="flex px-[20px]">
            <div
              v-for="item in fakeNavbarOrder"
              :key="item.id"
              @click="handleClickNavOrder(item.id)"
            >
              <div
                :class="
                  checkColor === item.id
                    ? 'px-[20px] text-[#cc3366] hover:border-[#cc3366] transition ease-in-out delay-100 cursor-pointer whitespace-nowrap border-[#cc3366] border-b-[3px] py-[15px]'
                    : 'px-[20px] text-[#384059] hover:border-[#cc3366] hover:text-[#cc3366] hover:border-b-[3px] transition ease-in-out delay-100 cursor-pointer whitespace-nowrap  py-[15px]'
                "
              >
                <span class="text-[14px] font-[600]">{{ item.title }}</span>
              </div>
            </div>
          </div>
        </div>
      </div>
      <!-- content -->
      <div class="w-full flex items-start">
        <div class="w-[32%] border-r-[1px] border-slate-200 bg-white">
          <div class="p-[20px] border-b-[1px] border-slate-200">
            <div
              class="flex items-center gap-[10px] bg-slate-200 rounded-xl overflow-hidden"
            >
              <input
                type="text"
                class="w-[85%] outline-none border-none bg-slate-200 rounded-tl-md rounded-bl-md"
                placeholder="Tìm kiếm đơn hàng"
              />
              <font-awesome-icon :icon="['fass', 'circle-xmark']" />
              <font-awesome-icon
                :icon="['fas', 'magnifying-glass']"
                class="text-[18px]"
              />
            </div>
          </div>
          <div class="min-h-[100vh] px-[35px] w-full">
            <!-- Các đơn hàng -->
            <div class="border-b-[1px] border-slate-300 pt-[30px] pb-[25px]">
              <!-- Header -->
              <div class="flex justify-between">
                <div class="flex flex-col">
                  <!-- Mã đơn -->
                  <span class="text-[14px] font-bold text-[#384059] uppercase">
                    #SL_14062003
                  </span>
                  <!-- Ngày tạo -->
                  <span class="text-[12px] text-[#384059]">17/05/2023</span>
                </div>
                <span v-if="checkStateOrder" class="text-orange-400 font-medium"
                  >Chờ xác nhận</span
                >
                <span v-else class="text-[14px] font-medium text-[#DB0804]"
                  >Đã hủy</span
                >
              </div>
              <div
                class="p-[10px] bg-slate-100 rounded-md overflow-hidden mt-[12px]"
              >
                <span v-if="checkStateOrder"
                  >Tạo đơn hàng , đang chờ xác nhận bởi nhân viên GlobalAI</span
                >
                <span v-else class="text-[12px]"
                  >Bạn đã hủy đơn hàng , Lý do : Muốn thay đổi sản phẩm trong
                  đơn hàng ( kích thước , màu sắc , số lượng , ...)</span
                >
              </div>
              <!-- Content -->
              <div class="mt-[10px] bg-slate-100 rounded-md overflow-hidden">
                <!-- img -->
                <div
                  class="flex border-b-[1px] border-slate-200 p-[10px] gap-[10px] items-center"
                >
                  <div class="w-[49px] h-[49px] rounded-md overflow-hidden">
                    <img
                      src="https://znews-photo.zingcdn.me/w660/Uploaded/qhj_yvobvhfwbv/2018_07_18/Nguyen_Huy_Binh1.jpg"
                      alt=""
                    />
                  </div>
                  <div
                    class="flex-1 flex justify-between items-center overflow-hidden"
                  >
                    <div>
                      <h2
                        class="font-semibold uppercase text-[12px] text-[#384059]"
                      >
                        đồ bộ quần áo thun đùi
                      </h2>
                      <span class="text-[12px] text-slate-500"
                        >Phân loại : XXL - Vàng</span
                      >
                      <p class="text-[12px]">
                        Giá :
                        <span class="text-red-500 text-[12px]">119.000</span>
                      </p>
                    </div>
                    <span>x1</span>
                  </div>
                </div>

                <div class="flex justify-between p-[10px]">
                  <span class="text-[12px]">Tổng 1 sản phẩm</span>
                  <span class="text-red-500 font-medium text-[12px] uppercase"
                    >240.700đ</span
                  >
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="flex-1 relative min-h-[100vh]">
          <!-- video quảng cáo -->
          <div class="px-[158px] py-[40px] mx-auto my-auto">
            <div class="w-full bg-white p-[20px]">
              <h1 class="text-[24px] text-[#384059]">#14062003</h1>
              <span class="text-center">Trạng thái đơn</span>
              <div class="flex items-center justify-between mt-[20px]">
                <h2 class="font-medium text-[#384059] text-[16px]">
                  Trạng thái đơn hàng
                </h2>
                <span class="text-[14px] font-medium text-blue-500"
                  >Xem chi tiết ></span
                >
              </div>
              <div
                class="p-[20px] bg-slate-100 rounded-md overflow-hidden mt-[12px]"
              >
                <span v-if="checkStateOrder"
                  >Tạo đơn hàng , đang chờ xác nhận bởi nhân viên GlobalAI</span
                >
                <span v-else class="text-[14px] text-[#384059]"
                  >Bạn đã hủy đơn hàng , Lý do : Muốn thay đổi sản phẩm trong
                  đơn hàng ( kích thước , màu sắc , số lượng , ...)</span
                >
              </div>
              <div class="flex items-center justify-between mt-[20px]">
                <h2 class="font-medium text-[#384059] text-[16px]">
                  Vận Chuyển
                </h2>
                <span class="text-[14px] font-medium text-blue-500"
                  >Xem chi tiết ></span
                >
              </div>
              <div
                class="p-[20px] bg-slate-100 rounded-md overflow-hidden mt-[12px]"
              >
                <h2
                  class="text-[16px] text-[#384059] font-medium text-[#384059]"
                >
                  Best Express - Tiêu Chuẩn
                </h2>
                <span class="text-[16px] text-[#384059]">
                  Thời gian giao hàng dự kiến
                  <span class="font-medium">19/5-20/5</span></span
                >
              </div>
              <div class="flex items-center justify-between mt-[20px]">
                <h2 class="font-medium text-[#384059] text-[16px]">
                  Phương thức thanh toán
                </h2>
              </div>
              <div
                class="p-[20px] bg-slate-100 rounded-md overflow-hidden mt-[12px]"
              >
                <span class="text-[16px]"> Khách thanh toán khi nhận hàng</span>
              </div>
              <div class="flex items-center justify-between mt-[20px]">
                <h2 class="font-medium text-[#384059] text-[16px]">
                  Người nhận hàng
                </h2>
              </div>
              <div
                class="p-[20px] flex flex-col gap-[4px] bg-slate-100 rounded-md overflow-hidden mt-[12px]"
              >
                <h2 class="text-[16px] font-medium text-red-500">
                  Nguyễn Tiến Dũng
                </h2>
                <p class="text-[14px] text-[#384059] font-[450]">+0866942653</p>
                <span class="text-[14px] text-[#38459] font-[450]"
                  >12, Phường 14, Quận 11, Thành phố Hồ Chí Minh</span
                >
              </div>
              <div class="flex items-center justify-between mt-[20px]">
                <h2 class="font-medium text-[#384059] text-[16px]">
                  Thông tin cho bạn
                </h2>
              </div>
              <div
                class="p-[20px] flex flex-col gap-[4px] bg-slate-100 rounded-md overflow-hidden mt-[12px]"
              >
                <div
                  class="border-b-[1px] border-white pb-[12px] flex justify-between items-center"
                >
                  <span class="text-[16px] text-[#384059]">Tổng tiền hàng</span>
                  <h2 class="text-[16px] text-[#384059] font-medium">
                    120.000đ
                  </h2>
                </div>
                <div class="flex justify-between items-center">
                  <span class="text-[16px] text-[#384059]">Phí vận chuyển</span>
                  <h2 class="text-[16px] text-[#384059] font-medium">
                    120.000đ
                  </h2>
                </div>
              </div>
              <!-- Sản phẩm -->
              <div class="mt-[10px] bg-white rounded-md overflow-hidden">
                <!-- img -->
                <div
                  class="flex border-b-[1px] border-slate-200 p-[10px] gap-[10px] items-start"
                >
                  <div class="w-[70px] h-[70px] rounded-md overflow-hidden">
                    <img
                      src="https://scontent.fhan2-3.fna.fbcdn.net/v/t39.30808-6/330156445_726528278941325_8030089236208389329_n.jpg?_nc_cat=101&ccb=1-7&_nc_sid=09cbfe&_nc_ohc=X-xXVJwff4YAX8-bRud&_nc_ht=scontent.fhan2-3.fna&oh=00_AfDxSWaGQonV2BtV9Ea60ACdyHzNIO5bklsM5CtRvGSSqw&oe=646A1FE5"
                      alt=""
                    />
                  </div>
                  <div
                    class="flex-1 flex justify-between items-center overflow-hidden"
                  >
                    <div>
                      <h2
                        class="font-semibold uppercase text-[16px] text-[#384059]"
                      >
                        đồ bộ quần áo thun đùi
                      </h2>
                      <span class="text-[14px] text-slate-500"
                        >Phân loại : XXL - Vàng</span
                      >
                      <p class="text-[14px] text-[#384059]">
                        Giá tối thiểu:
                        <span>119.000</span>
                      </p>
                      <p class="text-[14px] text-[#384059] text-red-500">
                        Giá bạn mua:
                        <span>119.000</span>
                      </p>
                      <p class="text-[14px]">Số lượng : 1</p>
                    </div>
                  </div>
                </div>
              </div>
              <div>
                <div
                  class="flex items-center justify-between mt-[20px] mb-[10px]"
                >
                  <h2 class="font-medium text-[#384059] text-[16px]">
                    Nhà cung cấp
                  </h2>
                </div>
                <div>
                  <!-- Header Card -->

                  <!-- Content Card -->
                  <div
                    class="flex bg-slate-100 rounded-md p-[20px] gap-[15px] cursor-pointer items-center"
                  >
                    <div
                      class="w-[70px] h-[70px] overflow-hidden bg-red-400 rounded-full"
                    >
                      <img
                        :src="imgSeaGull"
                        alt="img-card"
                        class="object-contain"
                      />
                    </div>
                    <!-- Content -->
                    <div>
                      <h3 class="text-[18px] text-[#384059] font-medium">
                        SeaGull
                      </h3>
                      <div>
                        <div class="flex items-center gap-[5px]">
                          <span class="text-[#6C757D]"
                            ><span class="text-[14px] font-bold text-[#CC3366]"
                              >71</span
                            >
                            sản phẩm</span
                          >
                          <span class="text-[#6C757D]"
                            ><span class="text-[14px] font-bold text-[#CC3366]"
                              >45.3K</span
                            >
                            đã bán</span
                          >
                        </div>
                        <div>
                          <span class="text-[#6C757D]"
                            ><span class="text-[14px] font-bold text-[#CC3366]"
                              >5.9K</span
                            >
                            seller bán hàng</span
                          >
                        </div>
                        <span class="text-[#6C757D]"
                          ><span class="text-[14px] font-bold text-[#CC3366]"
                            >5.5K</span
                          >
                          seller theo dõi</span
                        >
                        <!-- Số sao đánh giá -->
                        <div
                          class="flex gap-1 text-[#f8ac59] text-[14px] items-center"
                        >
                          <div class="flex items-center">
                            <font-awesome-icon :icon="['fas', 'star']" />
                            <font-awesome-icon :icon="['fas', 'star']" />
                            <font-awesome-icon :icon="['fas', 'star']" />
                            <font-awesome-icon :icon="['fas', 'star']" />
                            <font-awesome-icon :icon="['fas', 'star']" />
                          </div>
                          4.9/5
                        </div>
                        <!-- Vị trí -->
                        <div class="flex items-center gap-[5px] mt-1">
                          <div>
                            <font-awesome-icon
                              :icon="['fas', 'location-dot']"
                            />
                          </div>
                          <span class="text-[14px] font-[450] text-[#6C757D]"
                            >Thành phố Hà Nội và 1 kho khác</span
                          >
                        </div>
                      </div>
                    </div>
                    <div class="flex-1 pr-[10px]">
                      <font-awesome-icon
                        class="float-right text-[24px]"
                        :icon="['fas', 'angle-right']"
                      />
                    </div>
                  </div>
                </div>
              </div>
              <div class="flex items-center justify-center w-full">
            <div>
              <button class="text-[16px] mt-[30px] bg-red-400 flex px-[45px] py-[10px] font-medium text-white rounded-md items-center justify-center">Đặt lại đơn hàng</button>
                <p class="cursor-pointer text-[14px] text-blue-500 font-medium text-center mt-[20px]">Yêu cầu hỗ trợ</p></div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script setup>
import CardSupplier from "~~/components/Cards/CardSupplier.vue";

const checkColor = ref(1);

const fakeNavbarOrder = [
  {
    title: "Tất Cả",
    id: 1,
  },
  {
    title: "Chờ Thanh Toán",
    id: 2,
  },
  {
    title: "Chờ Xác Nhận",
    id: 3,
  },
  {
    title: "Chờ lấy hàng",
    id: 4,
  },
  {
    title: "Đang giao hàng",
    id: 5,
  },
  {
    title: "Đã giao & chờ đối soát",
    id: 6,
  },
  {
    title: "Đã đối soát",
    id: 7,
  },
  {
    title: "Đã hủy",
    id: 8,
  },
  {
    title: "Trả hàng",
    id: 9,
  },
];
const handleClickNavOrder = (id) => {
  checkColor.value = id;
};
definePageMeta({
  layout: "layout-default",
  name: "OrderLayout",
});
</script>
<style></style>
