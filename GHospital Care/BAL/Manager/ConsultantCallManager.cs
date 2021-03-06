﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GHospital_Care.DAL.Gateway;
using GHospital_Care.DAL.Model;

namespace GHospital_Care.BAL
{
    public class ConsultantCallManager
    {
        public DataTable GetAllIpAdmissionInfo()
        {
            return new ConsultantCallGatWay().GetAllIpAdmissionInfo();
        }

        public DataTable GenerateVoucherNo()
        {
            return new ConsultantCallGatWay().GenerateVoucherNo();
        }

        public DataTable GetNICUPatient()
        {
            return new ConsultantCallGatWay().GetNicuPatient();
        }


        public DataTable ViewConsultantMaster(DateTime FromDate, DateTime ToDate)
        {
            return new ConsultantCallGatWay().ViewConsultent(FromDate, ToDate);
        }

        public MessageModel SaveConsultantCall(ConsultantCall aConsultantCall, ConsultBillService aConsultBillService)
        {
            int rowAffect = 0;
            MessageModel aMessageModel=new MessageModel();
            rowAffect = new ConsultantCallGatWay().SaveConsultantCall(aConsultantCall);

            if (rowAffect>0)
            {
                rowAffect = new ConsultantCallGatWay().SaveCosultBilling(aConsultBillService);
                if (rowAffect>0)
                {
                    aMessageModel.MessageTitle = "Successful";
                    aMessageModel.MessageBody = "Save Successfully";
                }
            }
            else
            {
                aMessageModel.MessageTitle = "Warning!";
                aMessageModel.MessageBody = "Save to failed. Please try again.";
            }
            return aMessageModel;
        }


        public MessageModel UpdateConsultantCall(ConsultantCall aConsultantCall, ConsultBillService aConsultBillService)
        {
            int rowAffect = 0;
            MessageModel aMessageModel = new MessageModel();
            rowAffect = new ConsultantCallGatWay().UpdateConsultantCall(aConsultantCall);

            if (rowAffect > 0)
            {
                rowAffect = new ConsultantCallGatWay().UpdateCosultBilling(aConsultBillService);
                if (rowAffect > 0)
                {
                    aMessageModel.MessageTitle = "Successful";
                    aMessageModel.MessageBody = "Update Successfully";
                }
            }
            else
            {
                aMessageModel.MessageTitle = "Warning!";
                aMessageModel.MessageBody = "Save to failed. Please try again.";
            }
            return aMessageModel;
        }

    }
}
